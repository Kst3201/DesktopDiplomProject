namespace DesktopDiplomProject.ServerASP.Features.Authentification.Verifiers
{
    public interface IUserVerifier
    {
        bool VerifyUser(string username, string password);
        Task<bool> VerifyUserAsync(string username, string password);
    }
}
