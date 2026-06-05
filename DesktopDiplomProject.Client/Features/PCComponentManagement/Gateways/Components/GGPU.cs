using DesktopDiplomProject.Client.Controllers;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components
{
    public class GGPU : IGComponent<GPUDTO>
    {
        private ICommController _controller;

        public async Task<bool> AddItem(GPUDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GPUDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(GPUDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(GPUDTO item)
        {
            throw new NotImplementedException();
        }

        public GGPU(ICommController controller)
        {
            _controller = controller;
        }
    }
}
