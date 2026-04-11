using DesktopDiplomProject.Client.Commands;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views.Pages;
using DesktopDiplomProject.Client.Services.Navigation.Page;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.Pages
{
    public class ComponentsSelectionViewModel
    {
        private INavigationPageService _navigationPageService;
        private RelayCommand? _nextPageCommand;
        private List<string> _selectionMods;

        public ICommand? NextPageCommand => _nextPageCommand;

        public IReadOnlyList<string> SelectionMods
        {
            get => _selectionMods;
        }

        public ObservableCollection<object> PlugList
        {
            get;
        }

        public double Budget
        {
            get;
            set;
        }

        public double MinBudget
        {
            get;
            set;
        }

        public double MaxBudget
        {
            get;
            set;
        }

        public ComponentsSelectionViewModel(INavigationPageService navigationPageService)
        {
            _navigationPageService = navigationPageService;
            InitializeCommands();
            _selectionMods = new List<string>()
            {
                "Игровой",
                "Офисный",
                "Дизайнерский",
                "Сбалансированный"
            };
            PlugList = new ObservableCollection<object>()
            {
            };
            MinBudget = 0;
            MaxBudget = 10000000;
        }

        public void InitializeCommands()
        {
            _nextPageCommand = new RelayCommand(() => _navigationPageService?.ShowScopedPage<SelectionPCPage>());
        }
    }
}
