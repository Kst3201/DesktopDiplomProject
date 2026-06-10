using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.VideoCard
{
    public interface IVideoCardService : IComponentService<VideoCardDTO>
    {
        Task<IEnumerable<VideoCardModel>> GetAll();
        Task<IEnumerable<VideoCardModel>> GetAll(ICompatibilitySet set);
        Task<VideoCardDTO> GetFirstItemByGPU(string gpu);
    }
}
