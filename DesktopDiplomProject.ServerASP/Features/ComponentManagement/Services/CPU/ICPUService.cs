using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.CPU
{
    public interface ICPUService : IComponentService<CPUDTO>
    {
        Task<IEnumerable<CPUModel>> GetAll();
    }
}
