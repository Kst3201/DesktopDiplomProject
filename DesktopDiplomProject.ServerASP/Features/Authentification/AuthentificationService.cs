using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.ServerASP.Features.Authentification.Verifiers;
using DiplomDataLibrary.Authentification;

namespace DesktopDiplomProject.ServerASP.Features.Authentification
{
    public class AuthentificationService
    {
        private IUserVerifier _userVerifier;
        private UpgradePCApplicationContext _context;

        public AuthentificationService(UpgradePCApplicationContext context, IUserVerifier userVerifier)
        {
            _userVerifier = userVerifier;
            _context = context;
        }

        public async Task<AuthentificationResponse?> LoginUser(LoginRequest request)
        {
            if (!(await _userVerifier.VerifyUserAsync(request.Username, request.Password))) return null;
            throw new NotImplementedException();
        }

        public async Task<AuthentificationResponse> RegisterUser(RegisterRequest request)
        {

            throw new NotImplementedException();
        }

        public async Task<AuthentificationResponse> RefreshToken(RefreshRequest request)
        {

            throw new NotImplementedException();
        }
    }
}
