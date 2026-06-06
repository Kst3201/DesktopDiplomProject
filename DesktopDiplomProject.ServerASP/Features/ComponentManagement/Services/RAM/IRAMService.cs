using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.RAM
{
    public interface IRAMService : IComponentService<RAMDTO>
    {
        Task<IEnumerable<RAMModel>> GetAll();
    }
}
