using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Commands;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Views.Pages;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views.Pages;
using DesktopDiplomProject.Client.Services.Navigation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDiplomProject.Views.Components.Pages;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels
{
    public class ComponentsManagerPageViewModel : ObservableViewModel
    {
        private Dictionary<string, Type> _buttonDictionary;
        private RelayParamCommand? _openCommand;
        private INavigationPageService _navigationService;

        public IReadOnlyCollection<KeyValuePair<string, Type>> ButtonItems => _buttonDictionary.ToList();
        public ICommand? OpenComponentPageCommand => _openCommand;

        public ComponentsManagerPageViewModel(INavigationPageService navigationService)
        {
            _navigationService = navigationService;
            _buttonDictionary = new Dictionary<string, Type>()
            {
                ["Центральный процессоры"] = typeof(CPUsPage),
                ["Накопители"] = typeof(DrivesPage),
                ["Графический процессоры"] = typeof(GPUsPage),
                ["Материнские платы"] = typeof(MotherboardsPage),
                ["Оперативная память"] = typeof(RAMsPage),
                ["Тип ОЗУ"] = typeof(RAMTypesPage),
                ["Видеокарты"] = typeof(VideocardsPage)
            };
            OnPropertyChanged(nameof(ButtonItems));
            InitializeCommands();
        }

        public void InitializePage(System.Windows.Controls.Frame frame)
        {
            _navigationService.SetFrame(frame);
            CommandManager.InvalidateRequerySuggested();
        }

        private void InitializeCommands()
        {
            _openCommand = new RelayParamCommand((obj) =>
            {
                if (obj is KeyValuePair<string, Type> kvp)
                {
                    var method = _navigationService.GetType()
                    .GetMethod(nameof(INavigationPageService.ShowScopedPage))?
                    .MakeGenericMethod(kvp.Value);
                    if (method == null) return;
                    method.Invoke(_navigationService, null);
                }
            }, (obj) =>
            {
                return obj != null && obj is KeyValuePair<string, Type>;
            });
        }
    }
}
