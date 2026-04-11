using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Commands;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views.Pages;
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
        private INavigationPageService _navigationPageService;
        private INavigationWindowService _navigationWindowService;
        private RelayCommand? _openComponentsCommand;
        private RelayCommand? _openUserPCCommand;
        private RelayCommand? _closeCommand;
        private bool _isUserMenuOpen;

        public bool IsUserMenuOpen
        {
            get => _isUserMenuOpen;
            set => SetProperty(ref _isUserMenuOpen, value);
        }

        public ICommand? OpenComponentsCommand => _openComponentsCommand;
        public ICommand? OpenUserPCCommand => _openUserPCCommand;
        public ICommand? CloseCommand => _closeCommand;


        public MainViewModel(INavigationPageService navigationPageService, INavigationWindowService navigationWindowService)
        {
            _navigationPageService = navigationPageService;
            _navigationWindowService = navigationWindowService;
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
            _closeCommand = new RelayCommand(() =>
            {
                _navigationPageService.Clear();
                _navigationWindowService.GoBack();
            });
        }

    }
}
