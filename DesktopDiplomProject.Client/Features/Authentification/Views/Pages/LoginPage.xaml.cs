using DesktopDiplomProject.Client.Features.Authentification.ViewModels.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopDiplomProject.Client.Features.Authentification.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        LoginViewModel _viewModel;
        IServiceProvider _provider;

        public LoginPage(LoginViewModel viewModel, IServiceProvider provider)
        {
            _viewModel = viewModel;
            _provider = provider;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_provider.GetRequiredService<RegisterPage>());
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passBox)
            {
                _viewModel.Password = passBox.Password;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (_viewModel.IsPasswordShow)
                    HiddenPassword.Password = textBox.Text;
            }
        }
    }
}
