using DiplomDataLibrary.Assessments;

namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities
{
    public class NativeCompatibilitySet : ICompatibilitySet
    {
        public string? Socket { get; init; }

        public string? PCIEInterface { get; init; }

        public int? CountPCIELines { get; }

        public string? RAMType { get; init; }

        public IList<string>? DriveConnectionInterfaces { get; init; }

        public double? MaxPrice { get; init; }

        public FuzzyAssessments? MinAssessment { get; init; }

        public NativeCompatibilitySet()
        {
            Socket = null;
            PCIEInterface = null;
            CountPCIELines = null;
            RAMType = null;
            MaxPrice = null;
            MinAssessment = null;
            DriveConnectionInterfaces = null;
        }
    }
}
