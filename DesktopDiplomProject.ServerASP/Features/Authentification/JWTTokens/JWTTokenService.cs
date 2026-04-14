using DesktopDiplomProject.Database.Models.Entities.Authentification;
using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.ServerASP.Features.Authentification.JWTTokens.RefreshTokenGenerators;
using DiplomDataLibrary.Authentification;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DesktopDiplomProject.ServerASP.Features.Authentification.JWTTokens
{
    public class JWTTokenService : IJWTTokenService
    {
        private const int MAXREFRESHTOKENATTEMPTS = 10;
        private const int LIFETIMEINDAYS = 7;
        private IConfiguration _configuration;
        private IRefreshTokenGenerator _refreshTokenGenerator;
        private ILogger<JWTTokenService> _logger;
        private UpgradePCApplicationContext _context;

        public JWTTokenService(IConfiguration configureation, IRefreshTokenGenerator tokenGenerator,
            ILogger<JWTTokenService> logger, UpgradePCApplicationContext context)
        {
            _configuration = configureation;
            _refreshTokenGenerator = tokenGenerator;
            _logger = logger;
            _context = context;
        }

        public async Task<AuthentificationResponse?> GenerateTokensAsync(int userID, string role, string ipAddress)
        {
            var expiresMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryMinutes"]);
            var accessToken = GenerateAccessToken(userID, role, out string jwtID);
            var refreshToken = await GenerateRefreshToken();
            var refreshTokenEntity = CreateRefreshTokenEntity(refreshToken, userID, jwtID, ipAddress);

            await _context.RefreshTokens.AddAsync(refreshTokenEntity);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Generated tokens for user {UserID} from IP {IpAddress}", userID, ipAddress);

            return new AuthentificationResponse(accessToken, refreshToken,
                DateTime.UtcNow.AddMinutes(expiresMinutes), DateTime.UtcNow.AddDays(LIFETIMEINDAYS));
        }

        public async Task<AuthentificationResponse?> RefreshTokensAsync(string refreshToken, string ipAddress)
        {
            var storedToken = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token.Equals(refreshToken));
            if (storedToken == null)
            {
                _logger.LogWarning("Refresh token not found from IP {IpAddress}", ipAddress);
                return null;
            }
            if (!CheckStoredRefreshToken(storedToken, ipAddress)) return null;
            var user = await _context.Users.FirstOrDefaultAsync(x => x.ID.Equals(storedToken.UserID));
            if (user == null) return null;
            var expiresMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryMinutes"]);
            var newAccessToken = GenerateAccessToken(user.ID, user.Role.Name, out string newJWTID);
            var newRefreshToken = await GenerateRefreshToken();
            var refreshTokenEntity = CreateRefreshTokenEntity(newRefreshToken, user.ID, newJWTID, ipAddress);
            ReplaceRefreshToken(storedToken, refreshTokenEntity, ipAddress);
            await _context.RefreshTokens.AddAsync(refreshTokenEntity);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Tokens refreshed for user {UserID} from IP {IpAddress}", user.ID, ipAddress);

            return new AuthentificationResponse(newAccessToken, newRefreshToken,
                DateTime.UtcNow.AddMinutes(expiresMinutes), DateTime.UtcNow.AddDays(LIFETIMEINDAYS));
        }

        public async Task<bool> RevokeTokenAsync(string token, string ipAddress)
        {
            var storedToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token.Equals(token));
            if (storedToken == null || storedToken.IsRevoked) return false;

            RevokeRefreshToken(storedToken, ipAddress);

            await _context.SaveChangesAsync();
            _logger.LogInformation("Refresh token revoked for user {UserID} from IP {IpAddress}", storedToken.UserID, ipAddress);
            return true;
        }

        public async Task RevokeAllUserTokensAsync(int userID, string ipAddress)
        {
            var userTokens = await _context.RefreshTokens.Where(x => x.UserID.Equals(userID) && !x.IsRevoked)
                .ToListAsync();
            foreach (var token in userTokens)
            {
                RevokeRefreshToken(token, ipAddress);
            }
            await _context.SaveChangesAsync();
            _logger.LogInformation("All tokens revoked for user {UserID} from IP {IpAddress}", userID, ipAddress);
        }

        private bool CheckStoredRefreshToken(RefreshTokenEntity refreshToken, string ipAddress)
        {
            if (refreshToken.IsRevoked)
            {
                _logger.LogWarning("Revoked refresh token used from IP {IpAddress}", ipAddress);
                return false;
            }
            if (refreshToken.ExpiryDate < DateTime.UtcNow)
            {
                _logger.LogWarning("Expired refresh token used from IP {IpAddress}", ipAddress);
                return false;
            }
            return true;
        }

        private string GenerateAccessToken(int userID, string role, out string jwtID)
        {
            var secretKey = _configuration["Jwt:SecretKey"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expiryMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryMinutes"]);

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey ?? ""));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            jwtID = Guid.NewGuid().ToString();
            var claims = GetClaims(userID.ToString(), role, jwtID);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<string> GenerateRefreshToken()
        {
            string token = _refreshTokenGenerator.GenerateToken();
            int attempt = MAXREFRESHTOKENATTEMPTS;
            while (await _context.RefreshTokens.AnyAsync(x => x.Token.Equals(token)) && attempt-- > 0)
            {
                token = _refreshTokenGenerator.GenerateToken();
            }
            if (attempt == -1)
            {
                throw new Exception("Не удалось сгенерировать уникальный токен обновления");
            }
            return token;
        }

        private IList<Claim> GetClaims(string userID, string role, string jwtID)
        {
            return new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, userID),
                new Claim(JwtRegisteredClaimNames.Jti, jwtID),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                            ClaimValueTypes.Integer64),
                new Claim(ClaimTypes.Role, role)
            };
        }

        private RefreshTokenEntity CreateRefreshTokenEntity(string token, int userID, string jwtID, string ipAddress)
        {
            return new RefreshTokenEntity()
            {
                Token = token,
                UserID = userID,
                JWTID = jwtID,
                ExpiryDate = DateTime.UtcNow.AddDays(LIFETIMEINDAYS),
                CreatedByIP = ipAddress,
                CreatedAt = DateTime.UtcNow,
                IsRevoked = false
            };
        }

        private void ReplaceRefreshToken(RefreshTokenEntity token, RefreshTokenEntity newToken, string ipAddress)
        {
            token.IsRevoked = true;
            token.RevokedAt = DateTime.UtcNow;
            token.RevokedByIP = ipAddress;
            token.ReplacedByToken = newToken;
            token.UsedAt = DateTime.UtcNow;
            token.UsedByIP = ipAddress;
        }

        private void RevokeRefreshToken(RefreshTokenEntity token, string ipAddress)
        {
            token.IsRevoked = true;
            token.RevokedAt = DateTime.UtcNow;
            token.RevokedByIP = ipAddress;
        }
    }
}
