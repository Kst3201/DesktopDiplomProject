using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.Pages
{
    internal class ComponentsSelectionViewModel
    {
        private List<string> _selectionMods;

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

        public ComponentsSelectionViewModel()
        {
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
    }
}
