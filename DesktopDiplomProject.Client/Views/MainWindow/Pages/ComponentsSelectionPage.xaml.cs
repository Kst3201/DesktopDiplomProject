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

namespace DesktopDiplomProject.Client.Views.MainWindow.Pages
{
    /// <summary>
    /// Логика взаимодействия для ComponentsSelectionPage.xaml
    /// </summary>
    public partial class ComponentsSelectionPage : Page
    {
        public ComponentsSelectionPage()
        {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ParametersSelectionPage());
        }
    }
}
