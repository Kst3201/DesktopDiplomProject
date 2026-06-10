using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DiplomDataLibrary.Assessments;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Comparers
{
    public interface IScoreComparer : IComparer<IScore>
    {
        FuzzyAssessments? TargetAssessment { get; set; }
    }
}
