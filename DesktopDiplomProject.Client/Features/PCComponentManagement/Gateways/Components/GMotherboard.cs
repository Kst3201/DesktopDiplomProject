using DesktopDiplomProject.Client.Controllers;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components
{
    public class GMotherboard : IGComponent<MotherboardDTO>
    {
        private ICommController _controller;

        public async Task<bool> AddItem(MotherboardDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MotherboardDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(MotherboardDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(MotherboardDTO item)
        {
            throw new NotImplementedException();
        }

        public GMotherboard(ICommController controller)
        {
            _controller = controller;
        }
    }
}
