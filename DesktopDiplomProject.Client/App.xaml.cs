using DesktopDiplomProject.Client.Controllers;
using DesktopDiplomProject.Client.Features.Authentification.Gateways;
using DesktopDiplomProject.Client.Features.Authentification.ViewModels;
using DesktopDiplomProject.Client.Features.Authentification.ViewModels.Pages;
using DesktopDiplomProject.Client.Features.Authentification.Views;
using DesktopDiplomProject.Client.Features.Authentification.Views.Pages;
using DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels;
using DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.Pages;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views.Pages;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views.Pages.SelectionPCInfoPages;
using DesktopDiplomProject.Client.Managers.Sessions;
using DesktopDiplomProject.Client.Services.Navigation.Page;
using DesktopDiplomProject.Client.Services.Navigation.Window;
using DesktopDiplomProject.Client.Views.MainWindow.Pages.SelectionPCInfoPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Windows;

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
            builder.Services.AddSingleton<ISessionManager, SessionManager>();
            builder.Services.AddSingleton<INavigationWindowService, NavigationWindowService>();
            builder.Services.AddScoped<INavigationPageService, NavigationPageService>();
            builder.Services.AddTransient<MainWindow>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<ComponentsSelectionPage>();
            builder.Services.AddTransient<ComponentsSelectionViewModel>();
            builder.Services.AddTransient<SelectPCPage>();
            builder.Services.AddTransient<SelectViewModel>();
            builder.Services.AddTransient<SelectionPCPage>();
            builder.Services.AddTransient<SelectionPCViewModel>();
            builder.Services.AddTransient<UserPCPage>();
            builder.Services.AddTransient<UserPCViewModel>();
            builder.Services.AddTransient<AuthorizationWindow>();
            builder.Services.AddTransient<AuthorizationViewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<GAuthentification>();
            builder.Services.AddTransient<InfoPCPage>();
            builder.Services.AddTransient<InfoCPUPage>();
            builder.Services.AddTransient<InfoMotherboardPage>();
            builder.Services.AddTransient<InfoGPUPage>();
            builder.Services.AddTransient<InfoRAMPage>();
            builder.Services.AddTransient<InfoSSDPage>();
            builder.Services.AddTransient<InfoBlockPowerPage>();

            _host = builder.Build();

            await _host.StartAsync();

            INavigationWindowService navigationWindowService = _host.Services.GetRequiredService<INavigationWindowService>();
            navigationWindowService.ShowWindow<AuthorizationWindow>();
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
