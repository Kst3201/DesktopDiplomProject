using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Drive
{
    public interface IDriveService : IComponentService<DriveDTO>
    {
        Task<IEnumerable<DriveModel>> GetAll();
    }
}
