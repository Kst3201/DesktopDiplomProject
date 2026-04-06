using DesktopDiplomProject.Client.Controllers;
using DesktopDiplomProject.Client.Features.Authentification.ViewModels.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using TestDiplomProject.Views.Authorization;
using TestDiplomProject.Views.Authorization.Pages;
using TestDiplomProject.Views.MainWindow;

namespace TestDiplomProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IHost? _host; 

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            var builder = Host.CreateApplicationBuilder();
            builder.Services.AddSingleton<ICommController, HTTPSCommController>();
            builder.Services.AddTransient<MainWindow>();
            builder.Services.AddTransient<AuthorizationWindow>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();

            _host = builder.Build();

            await _host.StartAsync();

            Window window = _host.Services.GetRequiredService<AuthorizationWindow>();
            window.Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                if (_host != null)
                    await _host.StopAsync();
            }
        }
    }

}
