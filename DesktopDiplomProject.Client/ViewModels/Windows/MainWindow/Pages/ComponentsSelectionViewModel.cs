using DesktopDiplomProject.Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.ViewModels.Windows.MainWindow.Pages
{
    internal class ComponentsSelectionViewModel
    {
        private List<string> _selectionMods;

        public IReadOnlyList<string> SelectionMods
        {
            get => _selectionMods;
        }

        public ObservableCollection<TestModel> PlugList
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
            PlugList = new ObservableCollection<TestModel>()
            {
                new TestModel() { Name = "ПК"},
                new TestModel() { Name = "Процессор"},
                new TestModel() { Name = "Материнская плата"},
                new TestModel() { Name = "Видеокарта"},
                new TestModel() { Name = "Оперативная память"},
                new TestModel() { Name = "Долговременная память"},
                new TestModel() { Name = "Блок питания"}
            };
            MinBudget = 0;
            MaxBudget = 10000000;
        }
    }
}
