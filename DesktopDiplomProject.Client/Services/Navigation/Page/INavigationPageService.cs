using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesktopDiplomProject.Client.Services.Navigation.Page
{
    public interface INavigationPageService : IDisposable
    {
        System.Windows.Controls.Page? CurrentPage { get; }

        void SetFrame(Frame frame);

        void RemoveFrame();

        void ShowPage<TWindow>() where TWindow : System.Windows.Controls.Page;

        void ShowScopedPage<TWindow>() where TWindow : System.Windows.Controls.Page;

        void ClosePage<TWindow>() where TWindow: System.Windows.Controls.Page;

        void Clear();


    }
}
