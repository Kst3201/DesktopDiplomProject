using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Services.Navigation.Window
{
    public interface INavigationWindowService
    {
        void ShowWindow<TWindow>() where TWindow : System.Windows.Window;

        void ShowDialogWindow<TWindow>() where TWindow : System.Windows.Window;

        void ShowWindowAndHideParent<TWindow>() where TWindow : System.Windows.Window;

        void ShowWindowAndCloseParent<TWindow>() where TWindow : System.Windows.Window;

        void GoBack();
    }
}
