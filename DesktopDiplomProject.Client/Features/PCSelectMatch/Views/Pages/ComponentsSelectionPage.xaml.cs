using DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.Pages;
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
    /// Логика взаимодействия для ComponentsSelectionPage.xaml
    /// </summary>
    public partial class ComponentsSelectionPage : Page
    {

        private ComponentsSelectionViewModel _viewModel;

        public ComponentsSelectionPage(ComponentsSelectionViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.InitializeSelectionMods();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Unload();
        }
    }
}
