using DesktopDiplomProject.Server.Models.Entities;
using DiplomDataLibrary.PCComponents.DTO;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.NamedUnits
{
    public interface IComponentNamedUnitService<TEntity>
        where TEntity : IEntityWithName, new()
    {
        Task<IEnumerable<ComponentNamedUnitDTO>> GetItems();
        Task<TEntity> GetOrAddByName(string value);
        Task<ComponentNamedUnitDTO> Update(string name, ComponentNamedUnitDTO value);
        Task<ComponentNamedUnitDTO> GetItem(string name);
        Task RemoveItem(string name);
    }
}
