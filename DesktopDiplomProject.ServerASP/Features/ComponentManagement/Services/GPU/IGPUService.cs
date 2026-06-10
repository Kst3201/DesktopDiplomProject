using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.GPU
{
    public interface IGPUService : IComponentService<GPUDTO>
    {
        Task<IEnumerable<GPUModel>> GetAll();
    }
}
