using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components
{
    public interface IGComponent<T> where T : class
    {
        Task<IEnumerable<T>> GetItems();
        Task<T> GetItem(string name);
        Task<bool> AddItem(T item);
        Task<bool> RemoveItem(string name);
        Task<bool> UpdateItem(string name, T item);
    }
}
