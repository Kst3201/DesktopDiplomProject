using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;

namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Models.PersonalComputers
{
    public interface IPCModel
    {
        CPUModel CPU { get; init; }
        DriveModel Drive { get; init; }
        MotherboardModel Motherboard { get; init; }
        RAMModel RAM { get; init; }
        VideoCardModel VideoCard { get; init; }
        double Price { get; init; }
        IScore TotalScore { get; init; }
    }
}
