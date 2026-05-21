using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities.Authentification;
using DesktopDiplomProject.ServerASP.Features.Authentification.JWTTokens;
using DesktopDiplomProject.ServerASP.Features.Authentification.Password.Cryptographer;
using DesktopDiplomProject.ServerASP.Features.Authentification.Verifiers;
using DiplomDataLibrary.Authentification.Requests;
using DiplomDataLibrary.Authentification.Responses;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace DesktopDiplomProject.ServerASP.Features.Authentification
{
    public class AuthentificationService : IAuthentificationService
    {
        private IUserVerifier _userVerifier;
        private IPasswordService _passwordService;
        private IJWTTokenService _jwtTokenService;
        private ILogger<AuthentificationService> _logger;
        private UpgradePCApplicationContext _context;

        public AuthentificationService(UpgradePCApplicationContext context, IPasswordService passwordService,
            IUserVerifier userVerifier, IJWTTokenService jwtTokenService,
            ILogger<AuthentificationService> logger)
        {
            _passwordService = passwordService;
            _userVerifier = userVerifier;
            _jwtTokenService = jwtTokenService;
            _context = context;
            _logger = logger;
        }

        public async Task<AuthentificationResponse?> LoginUser(LoginRequest request, string ipAddress)
        {
            if (!(await _userVerifier.VerifyUserAsync(request.Username, request.Password))) return null;
            UserEntity? user = await _context.Users.Include(user => user.Role).FirstOrDefaultAsync(item => item.Login.Equals(request.Username));
            if (user == null) return new AuthentificationResponse("", "", DateTime.UtcNow, DateTime.UtcNow, AuthentificationStatus.UserNotFound);
            try
            {
                AuthentificationTokenModel? model = await _jwtTokenService.GenerateTokensAsync(user.ID, user.Role.Name, ipAddress);
                if (model == null) return new AuthentificationResponse("", "", DateTime.UtcNow, DateTime.UtcNow, AuthentificationStatus.RefreshTokenError);
                return new AuthentificationResponse(model.AccessToken, model.RefreshToken,
                    model.AccessTokenExpiresAt, model.RefreshTokenExpiresAt, AuthentificationStatus.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new AuthentificationResponse("", "", DateTime.UtcNow, DateTime.UtcNow, AuthentificationStatus.AnotherError);
            }
        }

        public async Task<RegistrationResponse> RegisterUser(RegisterRequest request)
        {
            try
            {
                if (await _context.Users.AnyAsync(item => item.Login.Equals(request.Username)))
                {
                    return new RegistrationResponse(request.Username, RegistrationStatus.UsernameIsUsed);
                }
                if (await _context.Users.AnyAsync(item => item.Email.Equals(request.Email)))
                {
                    return new RegistrationResponse(request.Username, RegistrationStatus.EmailIsUsed);
                }
                UserEntity newUser = new UserEntity()
                {
                    Login = request.Username,
                    Email = request.Email,
                    Password = _passwordService.GetHashPassword(request.Password),
                    RoleID = 2
                };
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                return new RegistrationResponse(request.Username, RegistrationStatus.OK);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message);
                return new RegistrationResponse(request.Username, RegistrationStatus.AnotherError);
            }
        }

        public async Task<AuthentificationResponse> RefreshToken(RefreshRequest request, string ipAddress)
        {
            try
            {
                var model = await _jwtTokenService.RefreshTokensAsync(request.RefreshToken, ipAddress);
                if (model == null) return new AuthentificationResponse("", "", DateTime.UtcNow, DateTime.UtcNow, AuthentificationStatus.RefreshTokenError);
                return new AuthentificationResponse(model.AccessToken, model.RefreshToken,
                    model.AccessTokenExpiresAt, model.RefreshTokenExpiresAt, AuthentificationStatus.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new AuthentificationResponse("", "", DateTime.UtcNow, DateTime.UtcNow, AuthentificationStatus.AnotherError);
            }
        }

        public async Task Logout(LogoutRequest request, string ipAddress)
        {
            try
            {
                if (request == null) throw new ArgumentNullException(nameof(request));
                await _jwtTokenService.RevokeTokenAsync(request.RefreshToken, ipAddress);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return;
            }
        }

        public async Task LogoutAllDevices(LogoutAllDevicesRequest request, string ipAddress)
        {
            try
            {
                if (request == null) throw new ArgumentNullException(nameof(request));
                await _jwtTokenService.RevokeAllUserTokensAsync(request.UserID, ipAddress);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return;
            }
        }
    }
}
