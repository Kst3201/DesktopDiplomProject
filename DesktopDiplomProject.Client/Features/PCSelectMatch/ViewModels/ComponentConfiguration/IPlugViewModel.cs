using DiplomDataLibrary.Assessments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.ComponentConfiguration
{
    public interface IPlugViewModel : INotifyPropertyChanged
    {
        bool IsUpgrading { get; set; }
        string Name { get; }
        double Price { get; set; }
        FuzzyAssessments Assessment { get; set; }
        IReadOnlyDictionary<FuzzyAssessments, string> AssessmentItems { get; }
    }
}
