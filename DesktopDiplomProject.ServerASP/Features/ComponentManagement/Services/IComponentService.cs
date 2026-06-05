using DiplomDataLibrary.PCComponents.DTO;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services
{
    public interface IComponentService<T> where T : BaseComponentNamedUnitDTO
    {
        Task<IEnumerable<T>> GetItems();
        Task<T> GetItem(string name);
        Task<T> GetItem(int id);
        Task<T> AddItem(T item);
        Task RemoveItem(string name);
        Task<T> UpdateItem(T item);

    }
}
