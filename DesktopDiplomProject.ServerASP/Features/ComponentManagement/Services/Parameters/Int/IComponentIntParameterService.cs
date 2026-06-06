using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int
{
    public interface IComponentIntParameterService<TEntity> 
        : IComponentParameterService<int, TEntity> 
        where TEntity : IntValueScoredEntity, new()
    {

    }
}
