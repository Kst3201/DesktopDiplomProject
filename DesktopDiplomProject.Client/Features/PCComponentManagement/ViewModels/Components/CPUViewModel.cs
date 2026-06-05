using DesktopDiplomProject.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components
{
    public class CPUViewModel : ObservableViewModel
    {
        private string _name;
        private string _manufacturer;
        private string _model;
        private string _socket;
        private int _countCores;
        private int _countThreads;
        private int _baseFrequency;
        private string _ramType;
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

        public string Socket
        {
            get => _socket;
            set => SetProperty(ref _socket, value);
        }

        public int CountCores
        {
            get => _countCores;
            set => SetProperty(ref _countCores, value);
        }

        public int CountThreads
        {
            get => _countThreads;
            set => SetProperty(ref _countThreads, value);
        }

        public int BaseFrequency
        {
            get => _baseFrequency;
            set => SetProperty(ref _baseFrequency, value);
        }

        public string RAMType
        {
            get => _ramType;
            set => SetProperty(ref _ramType, value);
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

        public CPUViewModel()
        {
            _name = string.Empty;
            _manufacturer = string.Empty;
            _model = string.Empty;
            _socket = string.Empty;
            _countCores = 0;
            _countThreads = 0;
            _baseFrequency = 0;
            _ramType = string.Empty;
            _price = 0;
            _totalScore = 0;
        }
    }
}
