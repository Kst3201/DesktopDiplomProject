using DesktopDiplomProject.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.ViewModels.Pages
{
    internal class LoginViewModel : ObservableViewModel
    {
        private string _username;
        private string _password;
        private bool _isHidePassword;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get
            {
                if (!IsHidePassword) return _password;
                return new string('*', _password.Length);
            }
            set => SetProperty(ref _password, value);
        }

        public bool IsHidePassword
        {
            get => _isHidePassword;
            set => SetProperty(ref _isHidePassword, value, () =>
            {
                OnPropertyChanged(nameof(Password));
            });
        }

        public LoginViewModel()
        {
            _username = string.Empty;
            _password = string.Empty;
            _isHidePassword = true;
        }

    }
}
