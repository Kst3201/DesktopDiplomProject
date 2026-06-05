using DesktopDiplomProject.Client.Controllers;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components
{
    public class GCPU : IGComponent<CPUDTO>
    {
        private ICommController _controller;

        public async Task<bool> AddItem(CPUDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CPUDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(CPUDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(CPUDTO item)
        {
            throw new NotImplementedException();
        }

        public GCPU(ICommController controller)
        {
            _controller = controller;
        }
    }
}
