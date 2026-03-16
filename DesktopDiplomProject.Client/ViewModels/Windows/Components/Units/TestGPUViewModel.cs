using DesktopDiplomProject.Client.Models;
using DesktopDiplomProject.Client.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.ViewModels.Windows.Components.Units
{
    class TestGPUViewModel
    {
        private TestParameterModel _capacityVideoMemory;
        private TestParameterModel _monitorCount;
        private TestParameterModel _memoryFrequency;
        private TestParameterModel _price;
        private TestParameterModel _capacityThroughput;

        public string CapacityVideoMemory { get => _capacityVideoMemory.Value; set => _capacityVideoMemory.Value = value; }
        public string CapacityVideoMemoryName { get => _capacityVideoMemory.Name; }

        public string MonitorCount { get => _monitorCount.Value; set => _monitorCount.Value = value; }
        public string MonitorCountName { get => _monitorCount.Name; }

        public string MemoryFrequency { get => _memoryFrequency.Value; set => _memoryFrequency.Value = value; }
        public string MemoryFrequencyName { get => _memoryFrequency.Name; }

        public string Price { get => _price.Value; set => _price.Value = value; }
        public string PriceName { get => _price.Name; }

        public string CapacityThroughput { get => _capacityThroughput.Value; set => _capacityThroughput.Value = value; }
        public string CapacityThroughputName { get => _capacityThroughput.Name; }

        public TestGPUViewModel()
        {
            Random random = new Random();
            _capacityVideoMemory = new TestParameterModel("Объем видеопамяти", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(1000, 8000).ToString() };
            _monitorCount = new TestParameterModel("Число мониторов", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(1, 4).ToString() };
            _memoryFrequency = new TestParameterModel("Частота видеопамяти", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(1000, 8000).ToString() };
            _price = new TestParameterModel("Цена", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(10000, 800000).ToString() };
            _capacityThroughput = new TestParameterModel("Объем шины", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(64, 3248).ToString() };
        }

        public TestGPUModel GetModel()
        {
            var result = new TestGPUModel()
            {
                CapacityVideoMemory = CapacityVideoMemory,
                MonitorCount = MonitorCount,
                MemoryFrequency = MemoryFrequency,
                Price = Price,
                CapacityThroughput = CapacityThroughput
            };
            return result;
        }
    }
}
