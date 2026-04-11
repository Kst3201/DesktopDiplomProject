using DesktopDiplomProject.Client.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesktopDiplomProject.Client.Services.Navigation.Page
{
    public class NavigationPageService : INavigationPageService, IDisposable
    {
        private IServiceProvider _serviceProvider;
        private Dictionary<Type, System.Windows.Controls.Page> _pages;
        private Dictionary<System.Windows.Controls.Page, IServiceScope> _scopesDictionary;
        private System.Windows.Controls.Page? _currentPage;
        private Frame? _currentFrame;

        public NavigationPageService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _pages = new Dictionary<Type, System.Windows.Controls.Page>();
            _scopesDictionary = new Dictionary<System.Windows.Controls.Page, IServiceScope>();
            _currentFrame = null;
            _currentPage = null;
        }

        public System.Windows.Controls.Page? CurrentPage => _currentPage;

        public void Clear()
        {
            _pages.Clear();
            foreach (var scope in _scopesDictionary.Values)
            {
                scope.Dispose();
            }
            _scopesDictionary.Clear();
        }

        public void ClosePage<TWindow>() where TWindow : System.Windows.Controls.Page
        {
            if (_pages.TryGetValue(typeof(TWindow), out var result))
            {
                _pages.Remove(typeof(TWindow));
                if (_scopesDictionary.TryGetValue(result, out var scope))
                {
                    _scopesDictionary.Remove(result);
                    scope.Dispose();
                }
            }
            LoadPage();
        }

        public void Dispose()
        {
            foreach (var kvp in _scopesDictionary)
            {
                kvp.Value.Dispose();
            }
            _currentPage = null;
            _currentFrame = null;
        }

        public void RemoveFrame()
        {
            _currentFrame = null;
            Clear();
        }

        public void SetFrame(Frame frame)
        {
            _currentFrame = frame;
            Clear();
        }

        public void ShowPage<TWindow>() where TWindow : System.Windows.Controls.Page
        {
            if (_currentFrame == null) throw new ArgumentNullException(nameof(_currentFrame));
            if (!_pages.ContainsKey(typeof(TWindow)))
            {
                System.Windows.Controls.Page page = _serviceProvider.GetRequiredService<TWindow>();
                _pages[page.GetType()] = page;
            }
            _currentPage = _pages[typeof(TWindow)];
            LoadPage();
        }

        public void ShowScopedPage<TWindow>() where TWindow : System.Windows.Controls.Page
        {
            if (_currentFrame == null) throw new ArgumentNullException(nameof(_currentFrame));
            if (!_pages.ContainsKey(typeof(TWindow)))
            {
                IServiceScope scope = _serviceProvider.CreateScope();
                System.Windows.Controls.Page page = scope.ServiceProvider.GetRequiredService<TWindow>();
                _pages[page.GetType()] = page;
                _scopesDictionary[page] = scope;
            }
            _currentPage = _pages[typeof(TWindow)];
            LoadPage();
        }

        private void LoadPage()
        {
            if (CurrentPage != null)
                _currentFrame?.NavigationService.Navigate(CurrentPage);
            else
                _currentFrame?.NavigationService.Navigate(null);
        }
    }
}
