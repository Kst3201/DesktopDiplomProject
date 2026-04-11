using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Commands;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views.Pages;
using DesktopDiplomProject.Client.Services.Navigation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.Pages
{
    public class SelectViewModel : ObservableViewModel, IDisposable
    {
        private INavigationPageService _navigationPageService;
        private List<(Type type, bool isScoped)> _pageTypeList;
        private int _pageIndex;
        private RelayCommand? _nextPageCommand;
        private RelayCommand? _previousPageCommand;

        public ICommand? NextPageCommand => _nextPageCommand;
        public ICommand? PreviousPageCommand => _previousPageCommand;

        public SelectViewModel(INavigationPageService navigationPageService)
        {
            _navigationPageService = navigationPageService;
            _pageTypeList = new List<(Type type, bool isScoped)>()
            {
                (typeof(ComponentsSelectionPage), false),
                (typeof(SelectionPCPage), true)
            };
            _pageIndex = 0;
            InitializeCommands();
        }

        public void InitializePage(System.Windows.Controls.Frame frame)
        {
            _navigationPageService.SetFrame(frame);
            ShowPage();
        }

        public void InitializeCommands()
        {
            _nextPageCommand = new RelayCommand(() =>
            {
                _pageIndex++;
                ShowPage();
                CommandManager.InvalidateRequerySuggested();
            }, (obj) => _pageIndex >=0 && _pageIndex < _pageTypeList.Count - 1);
            _previousPageCommand = new RelayCommand(() =>
            {
                _pageIndex--;
                ShowPage();
                CommandManager.InvalidateRequerySuggested();
            }, (obj) => _pageIndex > 0 && _pageIndex < _pageTypeList.Count);
        }

        public void SetFrame(System.Windows.Controls.Frame frame)
        {
            _navigationPageService.SetFrame(frame);
        }

        private void ShowPage()
        {
            Type type = _pageTypeList[_pageIndex].type;
            bool isScoped = _pageTypeList[_pageIndex].isScoped;
            MethodInfo? showMethod = GetShowMethod(isScoped);
            if (showMethod == null) return;
            var genericMethod = showMethod.MakeGenericMethod(type);
            genericMethod?.Invoke(_navigationPageService, null);
        }

        private MethodInfo? GetShowMethod(bool scoped)
        {
            if (scoped)
            {
                return typeof(INavigationPageService).GetMethod(nameof(_navigationPageService.ShowScopedPage));
            }
            return typeof(INavigationPageService).GetMethod(nameof(_navigationPageService.ShowPage));
        }

        public void Dispose()
        {
            _navigationPageService.Dispose();
        }
    }
}
