using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Commands;
using DesktopDiplomProject.Client.Features.Authentification.Gateways;
using DesktopDiplomProject.Client.Features.Authentification.Views.Pages;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views;
using DesktopDiplomProject.Client.Managers.Sessions;
using DesktopDiplomProject.Client.Services.Navigation.Page;
using DesktopDiplomProject.Client.Services.Navigation.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DesktopDiplomProject.Client.Features.Authentification.ViewModels.Pages
{
    public class LoginViewModel : ObservableViewModel
    {
        private ISessionManager _sessionManager;
        private INavigationPageService _navigationPageService;
        private INavigationWindowService _navigationWindowService;
        private GAuthentification _gateway;
        private RelayCommand? _registrationCommand;
        private RelayCommand? _loginCommand;
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

        public ICommand? RegistrationCommand => _registrationCommand;
        public ICommand? LoginCommand => _loginCommand;

        public LoginViewModel(GAuthentification gateway, ISessionManager sessionManager,
            INavigationPageService navigationPageService, INavigationWindowService navigationWindowService)
        {
            _sessionManager = sessionManager;
            _navigationPageService = navigationPageService;
            _navigationWindowService = navigationWindowService;
            _gateway = gateway;
            _username = string.Empty;
            _password = string.Empty;
            _isPasswordHide = true;
            InitCommands();
        }

        private void InitCommands()
        {
            _registrationCommand = new RelayCommand(() =>
            {
                _navigationPageService.ShowPage<RegisterPage>();
            });
            _loginCommand = new RelayCommand(() =>
            {
                MessageBox.Show("!Вход!");
                _navigationWindowService.ShowWindowAndHideParent<MainWindow>();
            });
        }

    }
}
