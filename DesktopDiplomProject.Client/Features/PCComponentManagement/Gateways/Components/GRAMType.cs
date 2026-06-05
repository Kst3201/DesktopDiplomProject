using DesktopDiplomProject.Client.Controllers;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components
{
    public class GRAMType : IGComponent<RAMTypeDTO>
    {
        private ICommController _controller;

        public async Task<bool> AddItem(RAMTypeDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RAMTypeDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(RAMTypeDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(RAMTypeDTO item)
        {
            throw new NotImplementedException();
        }

        public GRAMType(ICommController controller)
        {
            _controller = controller;
        }
    }
}
