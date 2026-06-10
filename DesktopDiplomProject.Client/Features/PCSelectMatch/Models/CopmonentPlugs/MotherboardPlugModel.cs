using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using DiplomDataLibrary.Assessments;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Models.CopmonentPlugs
{
    public class MotherboardPlugModel : IComponentPlug<MotherboardModel>
    {
        public MotherboardModel? Item { get; set; }
        public double? MaxPrice { get; set; }
        public FuzzyAssessments? Assessment { get; set; }

        public MotherboardPlugModel() { }
    }
}
