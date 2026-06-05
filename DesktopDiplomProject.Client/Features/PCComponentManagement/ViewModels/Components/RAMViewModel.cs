using DesktopDiplomProject.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components
{
    public class RAMViewModel : ObservableViewModel
    {
        private string _name;
        private string _manufacturer;
        private string _model;
        private string _ramType;
        private int _singleModuleCapacity;
        private int _countModules;
        private int _frequency;
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

        public string RAMType
        {
            get => _ramType;
            set => SetProperty(ref _ramType, value);
        }

        public int SingleModuleCapacity
        {
            get => _singleModuleCapacity;
            set => SetProperty(ref _singleModuleCapacity, value);
        }

        public int CountModules
        {
            get => _countModules;
            set => SetProperty(ref _countModules, value);
        }

        public int Frequency
        {
            get => _frequency;
            set => SetProperty(ref _frequency, value);
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

        public RAMViewModel()
        {
            _name = string.Empty;
            _manufacturer = string.Empty;
            _model = string.Empty;
            _ramType = string.Empty;
            _singleModuleCapacity = 0;
            _countModules = 0;
            _frequency = 0;
            _price = 0;
            _totalScore = 0;
        }
    }
}
