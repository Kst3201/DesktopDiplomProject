using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Pages;
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

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для RAMTypesPage.xaml
    /// </summary>
    public partial class RAMTypesPage : Page
    {
        private RAMTypePageViewModel _viewModel;

        public RAMTypesPage(RAMTypePageViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.Initialize();
        }
    }
}
