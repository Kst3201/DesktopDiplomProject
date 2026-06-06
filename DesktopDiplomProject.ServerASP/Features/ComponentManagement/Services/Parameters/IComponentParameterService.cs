using DesktopDiplomProject.Server.Models.Entities;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters
{
    public interface IComponentParameterService<TValue, TEntity> 
        where TEntity : ScoredEntity, new()
        where TValue : struct
    {
        Task<TEntity> Add(TValue value);
        Task<TValue?> GetMax();
        Task<TValue?> GetMin();
        Task<TEntity> GetOrAdd(TValue value);
        Task Reassessment(TValue value);
    }
}
