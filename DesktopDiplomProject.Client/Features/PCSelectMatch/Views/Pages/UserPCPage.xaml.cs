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
    /// Логика взаимодействия для UserPCPage.xaml
    /// </summary>
    public partial class UserPCPage : Page
    {
        private UserPCViewModel _viewModel;

        public UserPCPage(UserPCViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

    }
}
