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
    public class RegisterViewModel : ObservableViewModel
    {
        private GAuthentification _gateway;
        private ISessionManager _sessionManager;
        private INavigationPageService _navigationPageService;
        private INavigationWindowService _navigationWindowService;
        private RelayCommand? _registrationCommand;
        private RelayCommand? _loginCommand;
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

        public ICommand? RegistrationCommand => _registrationCommand;
        public ICommand? LoginCommand => _loginCommand;

        public RegisterViewModel(GAuthentification gateway, ISessionManager sessionManager,
            INavigationPageService navigationPageService, INavigationWindowService navigationWindowService)
        {
            _gateway = gateway;
            _sessionManager = sessionManager;
            _navigationPageService = navigationPageService;
            _navigationWindowService = navigationWindowService;
            _username = string.Empty;
            _password = string.Empty;
            _rePassword = string.Empty;
            _email = string.Empty;
            InitCommands();
        }

        private void InitCommands()
        {
            _registrationCommand = new RelayCommand(() =>
            {
                MessageBox.Show("!Регистрация!");
                _navigationWindowService.ShowWindowAndHideParent<MainWindow>();
            });
            _loginCommand = new RelayCommand(() => _navigationPageService.ShowPage<LoginPage>());
        }
    }
}
