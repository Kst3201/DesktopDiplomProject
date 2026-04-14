using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.ServerASP.Features.Authentification.Password.Cryptographer;
using Microsoft.EntityFrameworkCore;
using Npgsql.TypeMapping;

namespace DesktopDiplomProject.ServerASP.Features.Authentification.Verifiers
{
    public class NativeUserVerifier : IUserVerifier
    {
        private IPasswordService _passwordService;
        private UpgradePCApplicationContext _context;

        public NativeUserVerifier(UpgradePCApplicationContext context, IPasswordService passwordService)
        {
            _passwordService = passwordService;
            _context = context;
        }

        public bool VerifyUser(string username, string password)
        {
            var user = _context.Users.Where(user => user.Login.Equals(username)).SingleOrDefault();
            if (user == null) return false;
            return _passwordService.VerifyPassword(password, user.Password);
        }

        public async Task<bool> VerifyUserAsync(string username, string password)
        {
            var user = await _context.Users.Where(user => user.Login.Equals(username)).SingleOrDefaultAsync();
            if (user == null) return false;
            return _passwordService.VerifyPassword(password, user.Password);
        }
    }
}
