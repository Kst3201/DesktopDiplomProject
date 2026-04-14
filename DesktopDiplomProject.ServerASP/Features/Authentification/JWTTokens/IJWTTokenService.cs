using DiplomDataLibrary.Authentification;

namespace DesktopDiplomProject.ServerASP.Features.Authentification.JWTTokens
{
    public interface IJWTTokenService
    {
        public Task<AuthentificationResponse?> GenerateTokensAsync(int userID, string role, string ipAddress);
        public Task<AuthentificationResponse?> RefreshTokensAsync(string refreshToken, string ipAddress);
        public Task<bool> RevokeTokenAsync(string toke, string ipAddress);
        public Task RevokeAllUserTokensAsync(int userID, string ipAddress);
    }
}
