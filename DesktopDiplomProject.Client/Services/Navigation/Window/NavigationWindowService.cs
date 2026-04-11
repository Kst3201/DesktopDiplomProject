using DesktopDiplomProject.Client.Services.Navigation.Page;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopDiplomProject.Client.Services.Navigation.Window
{
    public class NavigationWindowService : INavigationWindowService
    {
        private IServiceProvider _serviceProvider;
        private Dictionary<System.Windows.Window, IServiceScope> _scopeDictionary;
        private System.Windows.Window? _currentWindow;

        public NavigationWindowService(IServiceProvider serviceProvider)
        {
            _scopeDictionary = new Dictionary<System.Windows.Window, IServiceScope>();
            _serviceProvider = serviceProvider;
            _currentWindow = null;
        }

        public void GoBack()
        {
            if (_currentWindow == null)
            {
                Application.Current.Shutdown();
                return;
            }
            if (_currentWindow.Owner == null)
            {
                Application.Current.Shutdown();
                return;
            }
            _currentWindow = _currentWindow.Owner;
            _currentWindow.Show();
        }

        public void ShowDialogWindow<TWindow>() where TWindow : System.Windows.Window
        {
            System.Windows.Window newWindow = CreateWindow<TWindow>();
            newWindow.ShowDialog();
        }

        public void ShowWindow<TWindow>() where TWindow : System.Windows.Window
        {
            System.Windows.Window newWindow = CreateWindow<TWindow>();
            _currentWindow = newWindow;
            _currentWindow.Show();
        }

        public void ShowWindowAndCloseParent<TWindow>() where TWindow : System.Windows.Window
        {
            System.Windows.Window newWindow = CreateWindow<TWindow>();
            newWindow.Owner = null;
            _currentWindow?.Close();
            _currentWindow = newWindow;
            _currentWindow.Show();
        }

        public void ShowWindowAndHideParent<TWindow>() where TWindow : System.Windows.Window
        {
            System.Windows.Window newWindow = CreateWindow<TWindow>();
            _currentWindow?.Hide();
            _currentWindow = newWindow;
            _currentWindow.Show();
        }

        private System.Windows.Window CreateWindow<TWindow>() where TWindow : System.Windows.Window
        {
            IServiceScope scope = _serviceProvider.CreateScope();
            try
            {
                System.Windows.Window result = scope.ServiceProvider.GetRequiredService<TWindow>();
                _scopeDictionary[result] = scope;
                if (result == null) throw new ArgumentNullException(nameof(result));
                result.Owner = _currentWindow;
                result.Closed += OnWindowClosed;
                return result;
            }
            catch
            {
                scope.Dispose();
                throw;
            }
        }

        private void OnWindowClosed(object? sender, EventArgs e)
        {
            if (sender is System.Windows.Window window)
            {
                if (_scopeDictionary.TryGetValue(window, out var result))
                {
                    _scopeDictionary.Remove(window);
                    result.Dispose();
                }
                window.Closed -= OnWindowClosed;
            }
        }
    }
}
