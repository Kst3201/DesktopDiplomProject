using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.Authentification
{
    public class AuthentificationResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpiresAt { get; set; }
        public DateTime RefreshTokenExpiresAt { get; set; }


        public AuthentificationResponse(string accessToken, string refreshToken, DateTime accessAt, DateTime refreshAt)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            AccessTokenExpiresAt = accessAt;
            RefreshTokenExpiresAt = refreshAt;
        }
    }
}