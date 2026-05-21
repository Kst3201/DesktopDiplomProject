using DesktopDiplomProject.Client.Controllers;
using DesktopDiplomProject.Client.Features.Authentification.Models;
using DiplomDataLibrary.Authentification.Requests;
using DiplomDataLibrary.Authentification.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.Gateways
{
    public class GAuthentification
    {
        private ICommController _controller;

        public GAuthentification(ICommController controller)
        {
            _controller = controller;
        }

        public async Task<UserModel> Login(UserLoginModel model)
        {
            var request = new LoginRequest(model.UserName, model.Password);
            var response = await _controller.PostAsync<LoginRequest, AuthentificationResponse?>("api/authentification/login", request);
            if (response == null) throw new ArgumentNullException(nameof(response));
            ITokenModel accessToken = new TokenModel(response.AccessToken, response.AccessTokenExpiresAt);
            ITokenModel refreshToken = new TokenModel(response.RefreshToken, response.RefreshTokenExpiresAt);
            UserModel user = new UserModel(model.UserName, accessToken, refreshToken);
            return user;
        }

        public async Task<bool> Register(UserRegistrationModel model)
        {
            var request = new RegisterRequest(model.UserName, model.Email, model.Password);
            var response = await _controller.PostAsync<RegisterRequest>("api/authentification/register", request);
            return response;
        }

        public async Task<bool> Logout(UserLogoutModel model)
        {
            var request = new LogoutRequest(model.AccessToken, model.RefreshToken);
            var response = await _controller.PostAsync<LogoutRequest>("api/authentification/logout", request);
            return response;
        }
    }
}
