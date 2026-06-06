using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.VideoCard
{
    public interface IVideoCardService : IComponentService<VideoCardDTO>
    {
        Task<IEnumerable<VideoCardModel>> GetAll();
    }
}
