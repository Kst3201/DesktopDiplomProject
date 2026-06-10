using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.PersonalComputers;
using DiplomDataLibrary.Assessments;
using DiplomDataLibrary.PCBuild;

namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Services.PCBuild
{
    public interface IPCBuildService
    {
        Task<IEnumerable<PCDTO>> BuildComputers(PCBuildRequest buildDTO);
    }
    public interface IPCUpgradeService
    {
        Task<IEnumerable<PCDTO>> UpgradeComputer(PCUpgradeRequest upgradeDTO);
    }
}
