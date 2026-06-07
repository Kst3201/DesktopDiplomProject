using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels;
using DesktopDiplomProject.Client.Services.Navigation.Page;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Views
{
    /// <summary>
    /// Логика взаимодействия для ComponentsManagerPage.xaml
    /// </summary>
    public partial class ComponentsManagerPage : Page
    {
        private ComponentsManagerPageViewModel _viewModel;

        //public ComponentsManagerPageViewModel ViewModel => _viewModel;

        public ComponentsManagerPage(ComponentsManagerPageViewModel viewModel,
            INavigationPageService navigationPageService)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
            _viewModel.InitializePage(ComponentFrame);
        }
    }
}
