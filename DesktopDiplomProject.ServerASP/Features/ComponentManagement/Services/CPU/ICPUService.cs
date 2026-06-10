using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.CPU
{
    public interface ICPUService : IComponentService<CPUDTO>
    {
        Task<IEnumerable<CPUModel>> GetAll();
        Task<IEnumerable<CPUModel>> GetAll(ICompatibilitySet set);
        
    }
}
