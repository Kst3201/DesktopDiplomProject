using DesktopDiplomProject.Client.Controllers;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components
{
    public class GVideoCard : IGComponent<VideoCardDTO>
    {
        private ICommController _controller;

        public async Task<bool> AddItem(VideoCardDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VideoCardDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(VideoCardDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(VideoCardDTO item)
        {
            throw new NotImplementedException();
        }

        public GVideoCard(ICommController controller)
        {
            _controller = controller;
        }
    }
}
