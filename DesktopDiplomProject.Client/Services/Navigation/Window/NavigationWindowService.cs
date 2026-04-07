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
        private System.Windows.Window? _currentWindow;

        public NavigationWindowService(IServiceProvider serviceProvider)
        {
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
            System.Windows.Window newWindow = _serviceProvider.GetRequiredService<TWindow>();
            if (newWindow == null) throw new ArgumentNullException(nameof(newWindow));
            newWindow.Owner = _currentWindow;
            newWindow.ShowDialog();
        }

        public void ShowWindow<TWindow>() where TWindow : System.Windows.Window
        {
            System.Windows.Window newWindow = _serviceProvider.GetRequiredService<TWindow>();
            if (newWindow == null) throw new ArgumentNullException(nameof(newWindow));
            newWindow.Owner = _currentWindow;
            _currentWindow = newWindow;
            _currentWindow.Show();
        }

        public void ShowWindowAndCloseParent<TWindow>() where TWindow : System.Windows.Window
        {
            System.Windows.Window newWindow = _serviceProvider.GetRequiredService<TWindow>();
            if (newWindow == null) throw new ArgumentNullException(nameof(newWindow));
            _currentWindow?.Close();
            _currentWindow = newWindow;
            _currentWindow.Show();
        }

        public void ShowWindowAndHideParent<TWindow>() where TWindow : System.Windows.Window
        {
            System.Windows.Window newWindow = _serviceProvider.GetRequiredService<TWindow>();
            if (newWindow == null) throw new ArgumentNullException(nameof(newWindow));
            newWindow.Owner = _currentWindow;
            _currentWindow?.Hide();
            _currentWindow = newWindow;
            _currentWindow.Show();
        }
    }
}
