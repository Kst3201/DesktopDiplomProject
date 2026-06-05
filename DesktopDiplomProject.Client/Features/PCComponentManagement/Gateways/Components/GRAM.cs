using DesktopDiplomProject.Client.Controllers;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components
{
    public class GRAM : IGComponent<RAMDTO>
    {
        private ICommController _controller;

        public async Task<bool> AddItem(RAMDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RAMDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(RAMDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(RAMDTO item)
        {
            throw new NotImplementedException();
        }

        public GRAM(ICommController controller)
        {
            _controller = controller;
        }
    }
}
