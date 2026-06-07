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
        private const string CONTROLLERADDRESS = "api/VideoCard";
        private ICommController _controller;

        public GVideoCard(ICommController controller)
        {
            _controller = controller;
        }

        public async Task<bool> AddItem(VideoCardDTO item)
        {
            var result = await _controller.PostAsync(CONTROLLERADDRESS, item);
            return result;
        }

        public async Task<VideoCardDTO> GetItem(string name)
        {
            var result = await _controller.GetAsync<VideoCardDTO>($"{CONTROLLERADDRESS}/{name}");
            return result ?? new VideoCardDTO(string.Empty, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty);
        }

        public async Task<IEnumerable<VideoCardDTO>> GetItems()
        {
            var result = await _controller.GetAsync<IEnumerable<VideoCardDTO>>(CONTROLLERADDRESS);
            return result ?? new List<VideoCardDTO>();
        }

        public async Task<bool> RemoveItem(string name)
        {
            var result = await _controller.DeleteAsync($"{CONTROLLERADDRESS}/{name}");
            return result;
        }

        public async Task<bool> UpdateItem(string name, VideoCardDTO item)
        {
            var result = await _controller.PutAsync($"{CONTROLLERADDRESS}/{name}", item);
            return result;
        }
    }
}
