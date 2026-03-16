using DesktopDiplomProject.Client.Models;
using DesktopDiplomProject.Client.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.ViewModels.Windows.Components.Units
{
    class TestMotherboardViewModel
    {
        private TestParameterModel _countM2Slots;
        private TestParameterModel _countPCIEX16Slots;
        private TestParameterModel _countSATASlots;
        private TestParameterModel _price;
        private TestParameterModel _ramFrequency;
        private TestParameterModel _countRAMSlots;
        private TestParameterModel _valueRAM;
        private TestParameterModel _size;

        public string CountM2Slots { get => _countM2Slots.Value; set => _countM2Slots.Value = value; }
        public string CountM2SlotsName { get => _countM2Slots.Name; }

        public string CountPCIEX16Slots { get => _countPCIEX16Slots.Value; set => _countPCIEX16Slots.Value = value; }
        public string CountPCIEX16SlotsName { get => _countPCIEX16Slots.Name; }

        public string CountSATASlots { get => _countSATASlots.Value; set => _countSATASlots.Value = value; }
        public string CountSATASlotsName { get => _countSATASlots.Name; }

        public string Price { get => _price.Value; set => _price.Value = value; }
        public string PriceName { get => _price.Name; }

        public string RAMFrequency { get => _ramFrequency.Value; set => _ramFrequency.Value = value; }
        public string RAMFrequencyName { get => _ramFrequency.Name; }

        public string CountRAMSlots { get => _countRAMSlots.Value; set => _countRAMSlots.Value = value; }
        public string CountRAMSlotsName { get => _countRAMSlots.Name; }

        public string ValueRAM { get => _valueRAM.Value; set => _valueRAM.Value = value; }
        public string ValueRAMName { get => _valueRAM.Name; }

        public string Size { get => _size.Value; set => _size.Value = value; }
        public string SizeName { get => _size.Name; }

        public TestMotherboardViewModel()
        {
            Random random = new Random();
            _countM2Slots = new TestParameterModel("Количество разъемов M2", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(0, 4).ToString() };
            _countPCIEX16Slots = new TestParameterModel("Количество разъемов PCIEx16", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(1, 4).ToString() };
            _countSATASlots = new TestParameterModel("Количество разъемов SATA", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(2, 8).ToString() };
            _price = new TestParameterModel("Цена", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(3000, 80000).ToString() };
            _ramFrequency = new TestParameterModel("Предельная частота оперативной памяти", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(1000, 8000).ToString() };
            _countRAMSlots = new TestParameterModel("Количество слотов оперативной памяти", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(1, 8).ToString() };
            _valueRAM = new TestParameterModel("Предельный объем оперативной памяти", random.Next(0, 4) + random.NextDouble()) { Value = random.Next(1024, 64000).ToString() };
            _size = new TestParameterModel("Типо-размер", random.Next(0, 4) + random.NextDouble()) { Value = "Standard" };
        }

        public TestMotherboardModel GetModel()
        {
            var result = new TestMotherboardModel()
            {
                CountM2Slots = CountM2Slots,
                CountPCIEX16Slots = CountPCIEX16Slots,
                CountSATASlots = CountSATASlots,
                Price = Price,
                RAMFrequency = RAMFrequency,
                CountRAMSlots = CountRAMSlots,
                ValueRAM = ValueRAM,
                Size = Size
            };
            return result;  
        }
    }
}
