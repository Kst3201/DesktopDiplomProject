using DesktopDiplomProject.Server.Models.Entities;
using DiplomDataLibrary.PCComponents.DTO;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.NamedUnits
{
    public interface IComponentNamedUnitService<TEntity, TDTO>
        where TEntity : IEntityWithName, new()
        where TDTO : BaseComponentNamedUnitDTO
    {
        Task<IEnumerable<TDTO>> GetItems();
        Task<TEntity> GetOrAddByName(string value);
        Task<TDTO?> GetItem(string name);
        Task RemoveItem(string name);
    }
}
