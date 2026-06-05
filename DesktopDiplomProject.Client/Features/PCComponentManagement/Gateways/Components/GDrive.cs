using DesktopDiplomProject.Client.Controllers;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components
{
    public class GDrive : IGComponent<DriveDTO>
    {
        private ICommController _controller;

        public async Task<bool> AddItem(DriveDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DriveDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(DriveDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(DriveDTO item)
        {
            throw new NotImplementedException();
        }

        public GDrive(ICommController controller)
        {
            _controller = controller;
        }
    }
}
