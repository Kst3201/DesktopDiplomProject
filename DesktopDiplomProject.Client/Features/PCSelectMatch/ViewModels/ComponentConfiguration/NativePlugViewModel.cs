using DesktopDiplomProject.Client.Abstractions;
using DiplomDataLibrary.Assessments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.ComponentConfiguration
{
    public class NativePlugViewModel : ObservableViewModel, IPlugViewModel
    {
        private bool _isUpgrading;
        private string _name;
        private double _price;
        private Dictionary<FuzzyAssessments, string> _assessmentItems;
        private FuzzyAssessments _selectedAssessment;

        public bool IsUpgrading { get => _isUpgrading; set => SetProperty(ref _isUpgrading, value); }

        public string Name => _name;

        public double Price { get => _price; set => SetProperty(ref _price, value); }

        public FuzzyAssessments Assessment 
        { 
            get => _selectedAssessment;
            set => SetProperty(ref _selectedAssessment, value);
        }

        public IReadOnlyDictionary<FuzzyAssessments, string> AssessmentItems => _assessmentItems;

        public NativePlugViewModel(string name)
        {
            _isUpgrading = false;
            _name = name;
            _price = 0;
            _assessmentItems = new Dictionary<FuzzyAssessments, string>()
            {
                [FuzzyAssessments.Worst] = "Худшее",
                [FuzzyAssessments.Bad] = "Плохое",
                [FuzzyAssessments.Usual] = "Обычное",
                [FuzzyAssessments.Good] = "Хорошее",
                [FuzzyAssessments.Excellent] = "Лучшее" 
            };
            _selectedAssessment = FuzzyAssessments.Usual;
        }
    }
}
