using DesktopDiplomProject.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components
{
    public class MotherboardViewModel : ObservableViewModel
    {
        private string _name;
        private string _manufacturer;
        private string _model;
        private string _size;
        private string _socket;
        private string _ramType;
        private int _ramCountSlots;
        private int _maxRAMValue;
        private int _maxRAMFrequency;
        private string _pcieInterface;
        private int _countPCIEX16Slots;
        private int _countM2Slots;
        private int _countSATASlots;
        private double _price;
        private double _totalScore;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Manufacturer
        {
            get => _manufacturer;
            set => SetProperty(ref _manufacturer, value);
        }

        public string Model
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }

        public string Size
        {
            get => _size;
            set => SetProperty(ref _size, value);
        }

        public string Socket
        {
            get => _socket;
            set => SetProperty(ref _socket, value);
        }

        public string RAMType
        {
            get => _ramType;
            set => SetProperty(ref _ramType, value);
        }

        public int RAMCountSlots
        {
            get => _ramCountSlots;
            set => SetProperty(ref _ramCountSlots, value);
        }

        public int MaxRAMValue
        {
            get => _maxRAMValue;
            set => SetProperty(ref _maxRAMValue, value);
        }

        public int MaxRAMFrequency
        {
            get => _maxRAMFrequency;
            set => SetProperty(ref _maxRAMFrequency, value);
        }

        public string PCIEInterface
        {
            get => _pcieInterface;
            set => SetProperty(ref _pcieInterface, value);
        }

        public int CountPCIEX16Slots
        {
            get => _countPCIEX16Slots;
            set => SetProperty(ref _countPCIEX16Slots, value);
        }

        public int CountM2Slots
        {
            get => _countM2Slots;
            set => SetProperty(ref _countM2Slots, value);
        }

        public int CountSATASlots
        {
            get => _countSATASlots;
            set => SetProperty(ref _countSATASlots, value);
        }

        public double Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        public double TotalScore
        {
            get => _totalScore;
            set => SetProperty(ref _totalScore, value);
        }

        public MotherboardViewModel()
        {
            _name = string.Empty;
            _manufacturer = string.Empty;
            _model = string.Empty;
            _size = string.Empty;
            _socket = string.Empty;
            _ramType = string.Empty;
            _ramCountSlots = 0;
            _maxRAMValue = 0;
            _maxRAMFrequency = 0;
            _pcieInterface = string.Empty;
            _countPCIEX16Slots = 0;
            _countM2Slots = 0;
            _countSATASlots = 0;
            _price = 0;
            _totalScore = 0;
        }

    }
}
