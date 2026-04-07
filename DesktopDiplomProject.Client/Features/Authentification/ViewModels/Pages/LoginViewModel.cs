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
    public class LoginViewModel : ObservableViewModel
    {
        private ISessionManager _sessionManager;
        private GAuthentification _gateway;
        private string _username;
        private string _password;
        private bool _isPasswordHide;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsPasswordHide
        {
            get => _isPasswordHide;
            set => SetProperty(ref _isPasswordHide, value, () =>
            {
                OnPropertyChanged(nameof(IsPasswordShow));
            });
        }

        public bool IsPasswordShow => !IsPasswordHide;

        public LoginViewModel(GAuthentification gateway, ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
            _gateway = gateway;
            _username = string.Empty;
            _password = string.Empty;
            _isPasswordHide = true;
        }

    }
}
