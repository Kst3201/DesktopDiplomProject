using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.RAM
{
    public interface IRAMService : IComponentService<RAMDTO>
    {
        Task<IEnumerable<RAMModel>> GetAll();
        Task<IEnumerable<RAMModel>> GetAll(ICompatibilitySet set);
    }
}
