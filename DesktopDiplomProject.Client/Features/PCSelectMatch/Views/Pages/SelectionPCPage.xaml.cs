using DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.Pages;
using DesktopDiplomProject.Client.Views.MainWindow.Pages;
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

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectionPCPage.xaml
    /// </summary>
    public partial class SelectionPCPage : Page
    {
        private SelectionPCViewModel _viewModel;

        public SelectionPCPage(SelectionPCViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
            _viewModel.InitializePage(ComponentInfoFrame);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.InitializeItems();
        }
    }
}
