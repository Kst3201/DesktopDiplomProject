using DiplomDataLibrary.Authentification;

namespace DesktopDiplomProject.ServerASP.Features.Authentification.JWTTokens
{
    public interface IJWTTokenService
    {
        public Task<AuthentificationTokenModel?> GenerateTokensAsync(int userID, string role, string ipAddress);
        public Task<AuthentificationTokenModel?> RefreshTokensAsync(string refreshToken, string ipAddress);
        public Task<bool> RevokeTokenAsync(string toke, string ipAddress);
        public Task RevokeAllUserTokensAsync(int userID, string ipAddress);
    }
}
