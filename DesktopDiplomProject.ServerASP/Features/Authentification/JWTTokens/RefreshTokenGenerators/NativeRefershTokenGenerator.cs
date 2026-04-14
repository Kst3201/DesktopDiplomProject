using System.Security.Cryptography;

namespace DesktopDiplomProject.ServerASP.Features.Authentification.JWTTokens.RefreshTokenGenerators
{
    public class NativeRefershTokenGenerator : IRefreshTokenGenerator
    {
        private const int SIZE = 64;

        public string GenerateToken()
        {
            var bytes = new byte[SIZE];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
