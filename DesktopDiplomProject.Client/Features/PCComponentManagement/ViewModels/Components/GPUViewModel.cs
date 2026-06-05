using DesktopDiplomProject.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components
{
    public class GPUViewModel : ObservableViewModel
    {
        private string _name;
        private string _manufacturer;
        private string _model;
        private int _baseFrequency;
        private int _countUniversalProcessors;
        private int _countTexturerBlocks;
        private int _countRasterizationBlocks;
        private int _countRTCores;
        private int _countTensorCores;
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

        public int BaseFrequency
        {
            get => _baseFrequency;
            set => SetProperty(ref _baseFrequency, value);
        }

        public int CountUniversalProcessors
        {
            get => _countUniversalProcessors;
            set => SetProperty(ref _countUniversalProcessors, value);
        }

        public int CountTexturerBlocks
        {
            get => _countTexturerBlocks;
            set => SetProperty(ref _countTexturerBlocks, value);
        }

        public int CountRasterizationBlocks
        {
            get => _countRasterizationBlocks;
            set => SetProperty(ref _countRasterizationBlocks, value);
        }

        public int CountRTCores
        {
            get => _countRTCores;
            set => SetProperty(ref _countRTCores, value);
        }

        public int CountTensorCores
        {
            get => _countTensorCores;
            set => SetProperty(ref _countTensorCores, value);
        }

        public double TotalScore
        {
            get => _totalScore;
            set => SetProperty(ref _totalScore, value);
        }

        public GPUViewModel()
        {
            _name = string.Empty;
            _manufacturer = string.Empty;
            _model = string.Empty;
            _baseFrequency = 0;
            _countUniversalProcessors = 0;
            _countTexturerBlocks = 0;
            _countRasterizationBlocks = 0;
            _countRTCores = 0;
            _countTensorCores = 0;
            _totalScore = 0;
        }
    }
}
