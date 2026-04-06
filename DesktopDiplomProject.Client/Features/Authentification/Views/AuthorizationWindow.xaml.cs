using DesktopDiplomProject.Client.Features.Authentification.ViewModels.Pages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestDiplomProject.Views.Authorization.Pages;

namespace TestDiplomProject.Views.Authorization
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        IServiceProvider _provider;

        public AuthorizationWindow(IServiceProvider provider)
        {
            _provider = provider;
            InitializeComponent();
            AuthFrame.NavigationService.Navigate(_provider.GetRequiredService<LoginPage>());
        }
    }
}
