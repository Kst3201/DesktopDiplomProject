using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.RAM.RAMType
{
    public class RAMTypeService : IComponentService<RAMTypeDTO>
    {
        private DbContext _context;

        public async Task<bool> AddItem(RAMTypeDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<RAMTypeDTO> GetItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<RAMTypeDTO> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RAMTypeDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(RAMTypeDTO item)
        {
            throw new NotImplementedException();
        }

        public RAMTypeService(DbContext context)
        {
            _context = context;
        }
    }
}
