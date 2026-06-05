using DesktopDiplomProject.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components
{
    public class RAMTypeViewModel : ObservableViewModel
    {
        private string _name;
        private double _scoreOne;
        private double _scoreTwo;
        private double _scoreThree;
        private double _scoreFour;
        private double _scoreFive;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public double ScoreOne
        {
            get => _scoreOne;
            set => SetProperty(ref _scoreOne, value);
        }

        public double ScoreTwo
        {
            get => _scoreTwo;
            set => SetProperty(ref _scoreTwo, value);
        }

        public double ScoreThree
        {
            get => _scoreThree;
            set => SetProperty(ref _scoreThree, value);
        }

        public double ScoreFour
        {
            get => _scoreFour;
            set => SetProperty(ref _scoreFour, value);
        }

        public double ScoreFive
        {
            get => _scoreFive;
            set => SetProperty(ref _scoreFive, value);
        }

        public RAMTypeViewModel()
        {
            _name = string.Empty;
            _scoreOne = 0;
            _scoreTwo = 0;
            _scoreThree = 0;
            _scoreFour = 0;
            _scoreFive = 0;
        }
    }
}
