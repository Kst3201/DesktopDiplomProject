using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Features.Authentification.Gateways;
using DesktopDiplomProject.Client.Managers.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.ViewModels.Pages
{
    public class RegisterViewModel : ObservableViewModel
    {
        private GAuthentification _gateway;
        private ISessionManager _sessionManager;
        private string _username;
        private string _password;
        private string _rePassword;
        private string _email;

        public string UserName
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string RePassword
        {
            get => _rePassword;
            set => SetProperty(ref _rePassword, value);
        }

        public RegisterViewModel(GAuthentification gateway, ISessionManager sessionManager)
        {
            _gateway = gateway;
            _sessionManager = sessionManager;
            _username = string.Empty;
            _password = string.Empty;
            _rePassword = string.Empty;
            _email = string.Empty;
        }
    }
}
