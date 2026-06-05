using DesktopDiplomProject.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components
{
    public class VideoCardViewModel : ObservableViewModel
    {
        private string _name;
        private string _manufacturer;
        private string _model;
        private string _gpu;
        private string _pcieInterface;
        private int _countPCIELines;
        private int _recommendedBlockPower;
        private int _countPinsAdditionalPower;
        private int _capacityVideoMemory;
        private int _maxThroughputCapacity;
        private int _memoryFrequency;
        private int _countMonitors;
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

        public string GPU
        {
            get => _gpu;
            set => SetProperty(ref _gpu, value);
        }

        public string PCIEInterface
        {
            get => _pcieInterface;
            set => SetProperty(ref _pcieInterface, value);
        }

        public int CountPCIELines
        {
            get => _countPCIELines;
            set => SetProperty(ref _countPCIELines, value);
        }

        public int RecommendedBlockPower
        {
            get => _recommendedBlockPower;
            set => SetProperty(ref _recommendedBlockPower, value);
        }

        public int CountPinsAdditionalPower
        {
            get => _countPinsAdditionalPower;
            set => SetProperty(ref _countPinsAdditionalPower, value);
        }

        public int CapacityVideoMemory
        {
            get => _capacityVideoMemory;
            set => SetProperty(ref _capacityVideoMemory, value);
        }

        public int MaxThroughputCapacity
        {
            get => _maxThroughputCapacity;
            set => SetProperty(ref _maxThroughputCapacity, value);
        }

        public int MemoryFrequency
        {
            get => _memoryFrequency;
            set => SetProperty(ref _memoryFrequency, value);
        }

        public int CountMonitors
        {
            get => _countMonitors;
            set => SetProperty(ref _countMonitors, value);
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

        public VideoCardViewModel()
        {
            _name = string.Empty;
            _manufacturer = string.Empty;
            _model = string.Empty;
            _gpu = string.Empty;
            _pcieInterface = string.Empty;
            _countPCIELines = 0;
            _recommendedBlockPower = 0;
            _countPinsAdditionalPower = 0;
            _capacityVideoMemory = 0;
            _maxThroughputCapacity = 0;
            _memoryFrequency = 0;
            _countMonitors = 0;
            _price = 0;
            _totalScore = 0;
        }
    }
}
