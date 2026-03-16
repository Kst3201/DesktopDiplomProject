using DesktopDiplomProject.Client.Models;
using DesktopDiplomProject.Client.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.ViewModels.Windows.Components.Units
{
    class TestSSDViewModel
    {
        private TestParameterModel _capacity;
        private TestParameterModel _connectionInterface;
        private TestParameterModel _price;
        private TestParameterModel _speedDataTransfer;

        public string Capacity { get => _capacity.Value; set => _capacity.Value = value; }
        public string CapacityName { get => _capacity.Name; }

        public string ConnectionInterface { get => _connectionInterface.Value; set => _connectionInterface.Value = value; }
        public string ConnectionInterfaceName { get => _connectionInterface.Name; }

        public string Price { get => _price.Value; set => _price.Value = value; }
        public string PriceName { get => _price.Name; }

        public string SpeedDataTransfer { get => _speedDataTransfer.Value; set => _speedDataTransfer.Value = value; }
        public string SpeedDataTransferName { get => _speedDataTransfer.Name; }

        public TestSSDViewModel()
        {
            Random random = new Random();
            _capacity = new TestParameterModel("Объем", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(100, 10000).ToString() };
            _connectionInterface = new TestParameterModel("Интерфейс подключения", random.Next(0, 4) + random.NextDouble()) { Value = "M2" };
            _price = new TestParameterModel("Цена", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(1000, 80000).ToString() };
            _speedDataTransfer = new TestParameterModel("Скорость передачи даных", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(1000, 5000).ToString() };
        }

        public TestSSDModel GetModel()
        {
            var result = new TestSSDModel()
            {
                Capacity = Capacity,
                ConnectionInterface = ConnectionInterface,
                Price = Price,
                SpeedDataTransfer = SpeedDataTransfer
            };
            return result;
        }
    }
}
