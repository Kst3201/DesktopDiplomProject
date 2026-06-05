using DesktopDiplomProject.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components
{
    public class DriveViewModel : ObservableViewModel
    {
        private string _name;
        private string _manufacturer;
        private string _model;
        private int _capacity;
        private int _speedDataTransfer;
        private string _connectionInterface;
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

        public int Capacity
        {
            get => _capacity;
            set => SetProperty(ref _capacity, value);
        }

        public int SpeedDataTransfer
        {
            get => _speedDataTransfer;
            set => SetProperty(ref _speedDataTransfer, value);
        }

        public string ConnectionInterface
        {
            get => _connectionInterface;
            set => SetProperty(ref _connectionInterface, value);
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

        public DriveViewModel()
        {
            _name = string.Empty;
            _manufacturer = string.Empty;
            _model = string.Empty;
            _capacity = 0;
            _speedDataTransfer = 0;
            _connectionInterface = string.Empty;
            _price = 0;
            _totalScore = 0;
        }
    }
}
