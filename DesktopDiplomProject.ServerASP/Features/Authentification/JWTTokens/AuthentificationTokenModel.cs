namespace DesktopDiplomProject.ServerASP.Features.Authentification.JWTTokens
{
    public class AuthentificationTokenModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpiresAt { get; set; }
        public DateTime RefreshTokenExpiresAt { get; set; }

        public AuthentificationTokenModel(string accessToken, string refreshToken, DateTime accessTokenExpiresAt, DateTime refreshTokenExpiresAt)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            AccessTokenExpiresAt = accessTokenExpiresAt;
            RefreshTokenExpiresAt = refreshTokenExpiresAt;
        }
    }
}
