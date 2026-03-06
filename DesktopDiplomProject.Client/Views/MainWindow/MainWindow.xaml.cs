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
using TestDiplomProject.Views.Authorization.Pages;
using TestDiplomProject.Views.MainWindow.Pages;

namespace TestDiplomProject.Views.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool _isUserMenuOpen;

        public bool IsUserMenuOpen 
        { 
            get => _isUserMenuOpen; 
            set
            {
                _isUserMenuOpen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsUserMenuOpen)));
            }
        }

        public MainWindow()
        {
            _isUserMenuOpen = false;
            DataContext = this;
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new SelectionPCPage());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            IsUserMenuOpen = true;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Close();
            Application.Current.Shutdown();
        }

        private void SelectionButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new SelectionPCPage());
        }

        private void MyPCButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new UserPCPage());
        }
    }
}
