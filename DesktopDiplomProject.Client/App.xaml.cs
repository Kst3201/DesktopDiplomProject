using DesktopDiplomProject.Client.Controllers;
using DesktopDiplomProject.Client.Features.Authentification.Gateways;
using DesktopDiplomProject.Client.Features.Authentification.ViewModels;
using DesktopDiplomProject.Client.Features.Authentification.ViewModels.Pages;
using DesktopDiplomProject.Client.Features.Authentification.Views;
using DesktopDiplomProject.Client.Features.Authentification.Views.Pages;
using DesktopDiplomProject.Client.Features.Notifications;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Services;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Services.CopmonentCreators;
using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels;
using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Pages;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Views;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Views.Pages;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Gateway;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Services;
using DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels;
using DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.Pages;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views.Pages;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views.Pages.SelectionPCInfoPages;
using DesktopDiplomProject.Client.Managers.Sessions;
using DesktopDiplomProject.Client.Services.Navigation.Page;
using DesktopDiplomProject.Client.Services.Navigation.Window;
using DesktopDiplomProject.Client.Views.MainWindow.Pages.SelectionPCInfoPages;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using TestDiplomProject.Views.Components.Pages;

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
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, true);
            foreach (var pair in builder.Configuration.AsEnumerable())
            {
                Debug.WriteLine($"{pair.Key} = {pair.Value}");
            }
            builder.Services.AddSingleton<INotificationService, NativeNotificationService>();
            builder.Services.AddSingleton<ICommController, HTTPSCommController>();
            builder.Services.AddSingleton<HTTPSCommController>();
            builder.Services.AddSingleton<ISessionManager, SessionManager>();
            builder.Services.AddSingleton<INavigationWindowService, NavigationWindowService>();
            builder.Services.AddSingleton<IUserPCStateService, NativeUserPCStateService>();
            builder.Services.AddSingleton<IUserPCService, NativeUserPCService>();
            builder.Services.AddSingleton<IGComponent<CPUDTO>, GCPU>();
            builder.Services.AddSingleton<IGComponent<DriveDTO>, GDrive>();
            builder.Services.AddSingleton<IGComponent<GPUDTO>, GGPU>();
            builder.Services.AddSingleton<IGComponent<MotherboardDTO>, GMotherboard>();
            builder.Services.AddSingleton<GComponentNamedUnit>();
            builder.Services.AddSingleton<IGComponent<RAMDTO>, GRAM>();
            builder.Services.AddSingleton<IGComponent<RAMTypeDTO>, GRAMType>();
            builder.Services.AddSingleton<IGVideoCard, GVideoCard>();
            builder.Services.AddSingleton<IPCSelectConfigurateStateService, NativePCSelectConfigurationStateService>();
            builder.Services.AddSingleton<GPCPreset>();
            builder.Services.AddSingleton<GPCBuild>();
            builder.Services.AddScoped<ICPUCreator, CPUCreator>();
            builder.Services.AddScoped<IDriveCreator, DriveCreator>();
            builder.Services.AddScoped<IGPUCreator, GPUCreator>();
            builder.Services.AddScoped<IMotherboardCreator, MotherboardCreator>();
            builder.Services.AddScoped<INamedUnitCreator, NamedUnitCreator>();
            builder.Services.AddScoped<IRAMCreator, RAMCreator>();
            builder.Services.AddScoped<IRAMTypeCreator, RAMTypeCreator>();
            builder.Services.AddScoped<IVideoCardCreator, VideoCardCreator>();
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
            RegistrateComponentManagerServices(builder.Services);


            _host = builder.Build();

            await _host.StartAsync();

            INavigationWindowService navigationWindowService = _host.Services.GetRequiredService<INavigationWindowService>();
            navigationWindowService.ShowWindow<AuthorizationWindow>();
        }

        private void RegistrateComponentManagerServices(IServiceCollection services)
        {
            services.AddTransient<ComponentsManagerPage>();
            services.AddTransient<ComponentsManagerPageViewModel>();
            services.AddTransient<ComponentNamedOnlyUnitPage>();
            services.AddTransient<ComponentNamedUnitViewModel>();
            services.AddTransient<CPUsPage>();
            services.AddTransient<CPUPageViewModel>();
            services.AddTransient<DrivesPage>();
            services.AddTransient<DrivePageViewModel>();
            services.AddTransient<GPUsPage>();
            services.AddTransient<GPUPageViewModel>();
            services.AddTransient<MotherboardsPage>();
            services.AddTransient<MotherboardPageViewModel>();
            services.AddTransient<RAMsPage>();
            services.AddTransient<RAMPageViewModel>();
            services.AddTransient<RAMTypesPage>();
            services.AddTransient<RAMTypePageViewModel>();
            services.AddTransient<VideocardsPage>();
            services.AddTransient<VideoCardPageViewModel>();
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
