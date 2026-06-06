using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double
{
    public interface IComponentDoubleParameterService<TEntity> 
        : IComponentParameterService<double, TEntity> 
        where TEntity : DoubleValueScoredEntity, new()
    {

    }
}
