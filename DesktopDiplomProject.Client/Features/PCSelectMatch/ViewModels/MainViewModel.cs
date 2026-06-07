using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Commands;
using DesktopDiplomProject.Client.Features.Authentification.Gateways;
using DesktopDiplomProject.Client.Features.Authentification.Models;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Views;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views.Pages;
using DesktopDiplomProject.Client.Managers.Sessions;
using DesktopDiplomProject.Client.Services.Navigation.Page;
using DesktopDiplomProject.Client.Services.Navigation.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels
{
    public class MainViewModel : ObservableViewModel
    {
        private ISessionManager _sessionManager;
        private INavigationPageService _navigationPageService;
        private INavigationWindowService _navigationWindowService;
        private GAuthentification _gatewayAuth;
        private RelayCommand? _openComponentManagerCommand;
        private RelayCommand? _openComponentsCommand;
        private RelayCommand? _openUserPCCommand;
        private RelayCommand? _closeCommand;
        private RelayCommand? _goBackCommand;
        private bool _isUserMenuOpen;

        public bool IsUserMenuOpen
        {
            get => _isUserMenuOpen;
            set => SetProperty(ref _isUserMenuOpen, value);
        }

        public bool IsUserChanging
        {
            get;
            set;
        }

        public ICommand? OpenComponentManagerCommand => _openComponentManagerCommand;
        public ICommand? OpenComponentsCommand => _openComponentsCommand;
        public ICommand? OpenUserPCCommand => _openUserPCCommand;
        public ICommand? CloseCommand => _closeCommand;
        public ICommand? GoBackCommand => _goBackCommand;


        public MainViewModel(INavigationPageService navigationPageService, INavigationWindowService navigationWindowService, ISessionManager sessionManager, GAuthentification gAuth)
        {
            _navigationPageService = navigationPageService;
            _navigationWindowService = navigationWindowService;
            _sessionManager = sessionManager;
            _gatewayAuth = gAuth;
            IsUserChanging = false;
            InitCommands();
        }

        public void InitializePage(System.Windows.Controls.Frame frame)
        {
            _navigationPageService.SetFrame(frame);
            _navigationPageService.ShowScopedPage<SelectPCPage>();
            CommandManager.InvalidateRequerySuggested();
        }

        private void InitCommands()
        {
            _openComponentManagerCommand = new RelayCommand(() =>
            {
                _navigationPageService.ShowScopedPage<ComponentsManagerPage>();
                CommandManager.InvalidateRequerySuggested();
            }, (obj) =>
            {
                return !(_navigationPageService.CurrentPage?.GetType().Equals(typeof(ComponentsManagerPage)) ?? false);
            });
            _openComponentsCommand = new RelayCommand(() => 
            { 
                _navigationPageService.ShowScopedPage<SelectPCPage>();
                CommandManager.InvalidateRequerySuggested();
            }, (obj) =>
            {
                return !(_navigationPageService.CurrentPage?.GetType().Equals(typeof(SelectPCPage)) ?? false);
            });
            _openUserPCCommand = new RelayCommand(() => 
            { 
                _navigationPageService.ShowPage<UserPCPage>();
                CommandManager.InvalidateRequerySuggested();
            }, (obj) =>
            {
                return !(_navigationPageService.CurrentPage?.GetType().Equals(typeof(UserPCPage)) ?? false);

            });
            _closeCommand = new RelayCommand(async () =>
            {

                _navigationPageService.Clear();
                await Logout();
                _navigationWindowService.CloseApplication();
            });
            _goBackCommand = new RelayCommand(async () =>
            {
                IsUserChanging = true;
                _navigationPageService.Clear();
                await Logout();
                _navigationWindowService.GoBack();
            });
        }

        private async Task Logout()
        {
            if (_sessionManager != null && _gatewayAuth != null)
            {
                UserModel? user = _sessionManager.User;
                if (user == null) throw new ArgumentNullException(nameof(user));
                await _gatewayAuth.Logout(new Authentification.Models.UserLogoutModel(user.AccessToken.Token, user.RefreshToken.Token));
                _sessionManager.Logout();
            }
        }
    }

}
