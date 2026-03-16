using DesktopDiplomProject.Client.Models;
using DesktopDiplomProject.Client.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.ViewModels.Windows.Components.Units
{
    class TestCPUViewModel
    {
        private TestParameterModel _baseFrequency;
        private TestParameterModel _coreCount;
        private TestParameterModel _price;
        private TestParameterModel _socket;
        private TestParameterModel _threadCount;

        public string BaseFrequency { get => _baseFrequency.Value; set => _baseFrequency.Value = value; }
        public string BaseFrequencyName { get => _baseFrequency.Name; }

        public string CoreCount { get => _coreCount.Value; set => _coreCount.Value = value; }
        public string CoreCountName { get => _coreCount.Name; }

        public string Price { get => _price.Value; set => _price.Value = value; }
        public string PriceName { get => _price.Name; }

        public string Socket { get => _socket.Value; set => _socket.Value = value; }
        public string SocketName { get => _socket.Name; }

        public string ThreadCount { get => _threadCount.Value; set => _threadCount.Value = value; }
        public string ThreadCountName { get => _threadCount.Name; }

        public TestCPUViewModel()
        {
            Random random = new Random();
            _baseFrequency = new TestParameterModel("Базовая частота", random.Next(0, 4) + random.NextDouble()) { Value = "4.1" };
            _coreCount = new TestParameterModel("Количество ядер", random.Next(0, 4) + random.NextDouble()) { Value = "4" };
            _price = new TestParameterModel("Цена", random.Next(0, 4) + random.NextDouble()) { Value = "4000" };
            _socket = new TestParameterModel("Сокет", random.Next(0, 4) + random.NextDouble()) { Value = "AM4" };
            _threadCount = new TestParameterModel("Количество потоков", random.Next(0, 4) + random.NextDouble()) { Value = "4" };
        }

        public TestCPUModel GetModel()
        {
            TestCPUModel result = new TestCPUModel()
            {
                BaseFrequency = BaseFrequency,
                CoreCount = CoreCount,
                Price = Price,
                Socket = Socket,
                ThreadCount = ThreadCount
            };
            return result;
        }
    }
}
