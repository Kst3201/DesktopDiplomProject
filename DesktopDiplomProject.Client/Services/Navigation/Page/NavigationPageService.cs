using DesktopDiplomProject.Client.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Services.Navigation.Page
{
    public class NavigationPageService : ObservableViewModel, INavigationPageService
    {
        private IServiceProvider _serviceProvider;
        private Dictionary<Type, System.Windows.Controls.Page> _pages;
        private Stack<System.Windows.Controls.Page> _stackPages;

        public NavigationPageService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _pages = new Dictionary<Type, System.Windows.Controls.Page>();
            _stackPages = new Stack<System.Windows.Controls.Page>();
        }

        public System.Windows.Controls.Page? CurrentPage => (_stackPages?.TryPeek(out var result) ?? false) ? result : null;

        public void Clear()
        {
            _pages.Clear();
            _stackPages.Clear();
            OnPropertyChanged(nameof(CurrentPage));
        }

        public void ClosePage<TWindow>() where TWindow : System.Windows.Controls.Page
        {
            if (_pages.ContainsKey(typeof(TWindow)))
            {
                _pages.Remove(typeof(TWindow));
            }
            _stackPages.TryPop(out _);
            OnPropertyChanged(nameof(CurrentPage));
        }

        public void ShowPage<TWindow>() where TWindow : System.Windows.Controls.Page
        {
            if (_pages.TryGetValue(typeof(TWindow), out var result))
            {
                while (_stackPages.TryPeek(out var resultPop))
                {
                    if (result.Equals(resultPop)) break;
                    _stackPages.TryPop(out _);
                }
            }
            else
            {
                System.Windows.Controls.Page page = _serviceProvider.GetRequiredService<TWindow>();
                _pages[page.GetType()] = page;
                _stackPages.Push(page);
            }
            OnPropertyChanged(nameof(CurrentPage));
        }
    }
}
