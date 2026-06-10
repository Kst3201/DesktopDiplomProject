using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Drive
{
    public interface IDriveService : IComponentService<DriveDTO>
    {
        Task<IEnumerable<DriveModel>> GetAll();
        Task<IEnumerable<DriveModel>> GetAll(ICompatibilitySet set);
    }
}
