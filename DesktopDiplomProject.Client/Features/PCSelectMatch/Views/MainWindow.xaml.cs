using DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views.Pages;
using DesktopDiplomProject.Client.Services.Navigation.Page;
using DesktopDiplomProject.Client.Views.MainWindow.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private INavigationPageService _navigationPageService;
        private MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel, INavigationPageService navigationPageService, IServiceProvider provider)
        {

            _viewModel = viewModel;
            _navigationPageService = navigationPageService;
            DataContext = _viewModel;
            InitializeComponent();
            _viewModel.InitializePage(MainFrame);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.IsUserMenuOpen = true;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _viewModel.CloseCommand?.Execute(null);
        }
    }
}
