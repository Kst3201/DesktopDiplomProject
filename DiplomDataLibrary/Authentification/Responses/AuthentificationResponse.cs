using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.Authentification.Responses
{
    public enum AuthentificationStatus
    {
        OK = 0,
        UserNotFound,
        WarningPassword,
        RefreshTokenError,
        AccessTokenError,
        AnotherError
    }

    public class AuthentificationResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpiresAt { get; set; }
        public DateTime RefreshTokenExpiresAt { get; set; }
        public AuthentificationStatus Status { get; set; }




        public AuthentificationResponse(string accessToken, string refreshToken, DateTime accessTokenExpiresAt, DateTime refreshTokenExpiresAt, AuthentificationStatus status)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            AccessTokenExpiresAt = accessTokenExpiresAt;
            RefreshTokenExpiresAt = refreshTokenExpiresAt;
            Status = status;
        }
    }
}