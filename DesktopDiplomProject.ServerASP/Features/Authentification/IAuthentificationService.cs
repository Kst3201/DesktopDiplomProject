using DiplomDataLibrary.Authentification.Requests;
using DiplomDataLibrary.Authentification.Responses;

namespace DesktopDiplomProject.ServerASP.Features.Authentification
{
    public interface IAuthentificationService
    {
        public Task<AuthentificationResponse?> LoginUser(LoginRequest request, string ipAddress);

        public Task<RegistrationResponse> RegisterUser(RegisterRequest request);

        public Task<AuthentificationResponse> RefreshToken(RefreshRequest request, string ipAddress);

        public Task Logout(LogoutRequest request, string ipAddress);

        public Task LogoutAllDevices(LogoutAllDevicesRequest request, string ipAddress);
    }
}
