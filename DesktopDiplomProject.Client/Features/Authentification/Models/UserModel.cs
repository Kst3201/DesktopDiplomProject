using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.Models
{
    internal class UserModel
    {
        private string _username;
        private ITokenModel _accessToken;
        private ITokenModel _refreshToken;

        public string UserName => _username;
        public ITokenModel AccessToken
        {
            get => _accessToken;
            set => _accessToken = value;
        }

        public ITokenModel RefreshToken => _refreshToken;

        public UserModel(string username, ITokenModel accessToken, ITokenModel refreshToken)
        {
            _username = username;
            _accessToken = accessToken;
            _refreshToken = refreshToken;
        }
    }
}
