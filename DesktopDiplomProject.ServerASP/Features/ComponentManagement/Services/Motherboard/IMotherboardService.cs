using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Motherboard
{
    public interface IMotherboardService : IComponentService<MotherboardDTO>
    {
        Task<IEnumerable<MotherboardModel>> GetAll();
        Task<IEnumerable<MotherboardModel>> GetAll(ICompatibilitySet set);
    }
}
