namespace DesktopDiplomProject.ServerASP.Features.Authentification.Password.Cryptographer
{
    public interface IPasswordService
    {
        string GetHashPassword(string password);

        bool VerifyPassword(string password, string dbPassword);
    }
}
