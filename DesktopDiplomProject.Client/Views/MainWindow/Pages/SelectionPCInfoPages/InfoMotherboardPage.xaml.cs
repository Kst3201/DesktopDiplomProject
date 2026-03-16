using DesktopDiplomProject.Client.ViewModels.Windows.Components.Units;
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

namespace DesktopDiplomProject.Client.Views.MainWindow.Pages.SelectionPCInfoPages
{
    /// <summary>
    /// Логика взаимодействия для InfoMotherboardPage.xaml
    /// </summary>
    public partial class InfoMotherboardPage : Page
    {
        private TestMotherboardViewModel _viewModel;

        internal InfoMotherboardPage(TestMotherboardViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}
