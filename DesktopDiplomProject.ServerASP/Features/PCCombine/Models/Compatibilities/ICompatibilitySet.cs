using DiplomDataLibrary.Assessments;

namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities
{
    public interface ICompatibilitySet
    {
        string? Socket { get; }
        string? PCIEInterface { get; }
        int? CountPCIELines { get; }
        string? RAMType { get; }
        IList<string>? DriveConnectionInterfaces { get; }
        double? MaxPrice { get; }
        FuzzyAssessments? MinAssessment { get; }
    }
}
