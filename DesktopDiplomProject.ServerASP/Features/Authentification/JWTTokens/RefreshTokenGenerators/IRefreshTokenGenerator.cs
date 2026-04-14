namespace DesktopDiplomProject.ServerASP.Features.Authentification.JWTTokens.RefreshTokenGenerators
{
    public interface IRefreshTokenGenerator
    {
        public string GenerateToken();
    }
}
