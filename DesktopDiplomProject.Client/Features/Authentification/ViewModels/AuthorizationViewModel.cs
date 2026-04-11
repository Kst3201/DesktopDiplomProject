using DesktopDiplomProject.Client.Features.Authentification.Views.Pages;
using DesktopDiplomProject.Client.Services.Navigation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.ViewModels
{
    public class AuthorizationViewModel
    {
        private INavigationPageService _navigationPageService;

        public AuthorizationViewModel(INavigationPageService navigationPageService)
        {
            _navigationPageService = navigationPageService;
        }

        public void Initialize()
        {
            _navigationPageService.ShowPage<LoginPage>();
        }
    }
}
