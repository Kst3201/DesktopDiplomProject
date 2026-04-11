using DesktopDiplomProject.Client.Commands;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views.Pages.SelectionPCInfoPages;
using DesktopDiplomProject.Client.Services.Navigation.Page;
using DesktopDiplomProject.Client.Views.MainWindow.Pages.SelectionPCInfoPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.Pages
{
    public class SelectionPCViewModel
    {
        private INavigationPageService _navigationPageService;
        private RelayCommand? _toBPPageCommand;
        private RelayCommand? _toCPUPageCommand;
        private RelayCommand? _toGPUPageCommand;
        private RelayCommand? _toMBPageCommand;
        private RelayCommand? _toPCPageCommand;
        private RelayCommand? _toRAMPageCommand;
        private RelayCommand? _toSSDPageCommand;


        public ICommand? ToBPPageCommand => _toBPPageCommand;
        public ICommand? ToCPUPageCommand => _toCPUPageCommand;
        public ICommand? ToGPUPageCommand => _toGPUPageCommand;
        public ICommand? ToMBPageCommand => _toMBPageCommand;
        public ICommand? ToPCPageCommand => _toPCPageCommand;
        public ICommand? ToRAMPageCommand => _toRAMPageCommand;
        public ICommand? ToSSDPageCommand => _toSSDPageCommand;

        public SelectionPCViewModel(INavigationPageService navigationPageService)
        {
            _navigationPageService = navigationPageService;
            InitializeCommands();
        }

        public void InitializePage(System.Windows.Controls.Frame frame)
        {
            _navigationPageService?.SetFrame(frame);
            _navigationPageService?.Clear();
        }

        public void InitializeCommands()
        {
            _toBPPageCommand = new RelayCommand(() =>
                {
                    _navigationPageService?.ShowPage<InfoBlockPowerPage>();
                    CommandManager.InvalidateRequerySuggested();
                },
                (obj) => !_navigationPageService?.CurrentPage?.GetType()?.Equals(typeof(InfoBlockPowerPage)) ?? true);
            _toCPUPageCommand = new RelayCommand(() =>
                {
                    _navigationPageService?.ShowPage<InfoCPUPage>();
                    CommandManager.InvalidateRequerySuggested();
                },
                (obj) => !_navigationPageService?.CurrentPage?.GetType()?.Equals(typeof(InfoCPUPage)) ?? true);
            _toGPUPageCommand = new RelayCommand(() =>
                {
                    _navigationPageService?.ShowPage<InfoGPUPage>();
                    CommandManager.InvalidateRequerySuggested();
                },
                (obj) => !_navigationPageService?.CurrentPage?.GetType()?.Equals(typeof(InfoGPUPage)) ?? true);
            _toMBPageCommand = new RelayCommand(() => 
                { 
                    _navigationPageService?.ShowPage<InfoMotherboardPage>();
                    CommandManager.InvalidateRequerySuggested(); 
                },
                (obj) => !_navigationPageService?.CurrentPage?.GetType()?.Equals(typeof(InfoMotherboardPage)) ?? true);
            _toPCPageCommand = new RelayCommand(() => 
                { 
                    _navigationPageService?.ShowPage<InfoPCPage>(); 
                    CommandManager.InvalidateRequerySuggested(); 
                },
                (obj) => !_navigationPageService?.CurrentPage?.GetType()?.Equals(typeof(InfoPCPage)) ?? true);
            _toRAMPageCommand = new RelayCommand(() => 
                {
                    _navigationPageService?.ShowPage<InfoRAMPage>(); 
                    CommandManager.InvalidateRequerySuggested();
                },
                (obj) => !_navigationPageService?.CurrentPage?.GetType()?.Equals(typeof(InfoRAMPage)) ?? true);
            _toSSDPageCommand = new RelayCommand(() => 
                {
                    _navigationPageService?.ShowPage<InfoSSDPage>();
                    CommandManager.InvalidateRequerySuggested(); 
                },
                (obj) => !_navigationPageService?.CurrentPage?.GetType()?.Equals(typeof(InfoSSDPage)) ?? true);
        }

        public void SetFrame(System.Windows.Controls.Frame frame)
        {
            _navigationPageService.SetFrame(frame);
        }

        public void DropFrame()
        {
            _navigationPageService.RemoveFrame();
        }
    }
}
