using DesktopDiplomProject.Server.Models.Entities;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters
{
    public interface IComponentParameterService<TValue, TEntity> 
        where TEntity : ScoredEntity
        where TValue : struct
    {
        Task<TEntity> Add(TEntity value);
        Task<TValue?> GetMax();
        Task<TValue?> GetMin();
        Task<TEntity> GetOrAdd(TEntity value);
        Task Reassessment(TEntity value);
    }
}
