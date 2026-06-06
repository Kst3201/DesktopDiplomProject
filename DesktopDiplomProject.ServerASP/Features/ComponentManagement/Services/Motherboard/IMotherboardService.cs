using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Motherboard
{
    public interface IMotherboardService : IComponentService<MotherboardDTO>
    {
        Task<IEnumerable<MotherboardModel>> GetAll();
    }
}
