using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.Models
{
    public class UserLogoutModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserLogoutModel(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
