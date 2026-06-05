using DesktopDiplomProject.ServerASP.Features.Assessment.Models;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models
{
    public interface IComponentModel
    {
        string Name { get; set; }
        string Manufacturer { get; set; }
        string Model { get; set; }
        double Price { get; set; }
        IScore TotalScore { get; set; }

    }
}
