using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.Authentification.Requests
{
    public class LogoutRequest
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public LogoutRequest(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
