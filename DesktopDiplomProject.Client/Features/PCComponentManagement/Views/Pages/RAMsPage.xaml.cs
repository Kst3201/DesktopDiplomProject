using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components;
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

namespace TestDiplomProject.Views.Components.Pages
{
    /// <summary>
    /// Логика взаимодействия для RAMsPage.xaml
    /// </summary>
    public partial class RAMsPage : Page
    {
        private RAMPageViewModel _viewModel;

        public RAMsPage(RAMPageViewModel viewModel)
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
