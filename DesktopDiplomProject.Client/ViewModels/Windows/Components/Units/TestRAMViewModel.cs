using DesktopDiplomProject.Client.Models;
using DesktopDiplomProject.Client.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.ViewModels.Windows.Components.Units
{
    class TestRAMViewModel
    {
        private TestParameterModel _countModules;
        private TestParameterModel _frequency;
        private TestParameterModel _price;
        private TestParameterModel _capacitySingleModule;

        public string CountModules { get => _countModules.Value; set => _countModules.Value = value; }
        public string CountModulesName { get => _countModules.Name; }

        public string Frequency { get => _frequency.Value; set => _frequency.Value = value; }
        public string FrequencyName { get => _frequency.Name; }

        public string Price { get => _price.Value; set => _price.Value = value; }
        public string PriceName { get => _price.Name; }

        public string CapacitySingleModule { get => _capacitySingleModule.Value; set => _capacitySingleModule.Value = value; }
        public string CapacitySingleModuleName { get => _capacitySingleModule.Name; }

        public TestRAMViewModel()
        {
            Random random = new Random();
            _countModules = new TestParameterModel("Количество модулей в комплекте", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(1, 4).ToString() };
            _frequency = new TestParameterModel("Частота", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(1000, 8000).ToString() };
            _price = new TestParameterModel("Цена", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(3000, 80000).ToString() };
            _capacitySingleModule = new TestParameterModel("Цена", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(1024, 16000).ToString() };
        }

        public TestRAMModel GetModel()
        {
            var result = new TestRAMModel()
            {
                CountModules = CountModules,
                Frequency = Frequency,
                Price = Price,
                CapacitySingleModule = CapacitySingleModule
            };
            return result;
        }
    }
}
