using DesktopDiplomProject.Client.Features.Authentification.ViewModels;
using DesktopDiplomProject.Client.Features.Authentification.ViewModels.Pages;
using DesktopDiplomProject.Client.Services.Navigation.Page;
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

namespace DesktopDiplomProject.Client.Features.Authentification.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private INavigationPageService _navigationPageService;
        private AuthorizationViewModel _viewModel;

        public AuthorizationWindow(AuthorizationViewModel viewModel, INavigationPageService navigationPageService)
        {
            _viewModel = viewModel;
            _navigationPageService = navigationPageService;
            DataContext = _viewModel;
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            _navigationPageService.SetFrame(AuthFrame);
            _viewModel.Initialize();
        }

    }
}
