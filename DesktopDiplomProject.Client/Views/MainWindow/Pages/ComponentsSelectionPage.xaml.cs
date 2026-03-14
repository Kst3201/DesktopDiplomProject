using DesktopDiplomProject.Client.ViewModels.Windows.MainWindow.Pages;
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
using TestDiplomProject.Views.MainWindow.Pages;

namespace DesktopDiplomProject.Client.Views.MainWindow.Pages
{
    /// <summary>
    /// Логика взаимодействия для ComponentsSelectionPage.xaml
    /// </summary>
    public partial class ComponentsSelectionPage : Page
    {
        private ComponentsSelectionViewModel _viewModel;

        public ComponentsSelectionPage()
        {
            _viewModel = new ComponentsSelectionViewModel();
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SelectionPCPage());
        }
    }
}
