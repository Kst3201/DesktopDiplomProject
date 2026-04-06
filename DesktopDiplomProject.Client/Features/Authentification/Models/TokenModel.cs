using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.Models
{
    internal class TokenModel : ITokenModel
    {
        private string _token;
        private DateTime _expiresAt;

        public string Token => _token;
        public DateTime ExpiresAt => _expiresAt;

        public TokenModel(string token, DateTime expiresAt)
        {
            _token = token;
            _expiresAt = expiresAt;
        }
    }
}
