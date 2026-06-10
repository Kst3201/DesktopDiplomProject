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
        private const string CONTROLLERADDRESS = "api/Motherboard";
        private ICommController _controller;

        public GMotherboard(ICommController controller)
        {
            _controller = controller;
        }

        public async Task<bool> AddItem(MotherboardDTO item)
        {
            var result = await _controller.PostAsync(CONTROLLERADDRESS, item);
            return result;
        }

        public async Task<MotherboardDTO> GetItem(string name)
        {
            var result = await _controller.GetAsync<MotherboardDTO>($"{CONTROLLERADDRESS}/{name}");
            return result ?? new MotherboardDTO(string.Empty, string.Empty, string.Empty, 0, 0
                , string.Empty, string.Empty, string.Empty, string.Empty);
        }

        public async Task<MotherboardDTO> GetItemByFullname(string name)
        {
            var result = await _controller.GetAsync<MotherboardDTO>($"{CONTROLLERADDRESS}/ByFullname/{name}", true);
            return result ?? new MotherboardDTO(string.Empty, string.Empty, string.Empty, 0, 0
                , string.Empty, string.Empty, string.Empty, string.Empty);
        }

        public async Task<IEnumerable<MotherboardDTO>> GetItems()
        {
            var result = await _controller.GetAsync<IEnumerable<MotherboardDTO>>(CONTROLLERADDRESS);
            return result ?? new List<MotherboardDTO>();
        }

        public async Task<bool> RemoveItem(string name)
        {
            var result = await _controller.DeleteAsync($"{CONTROLLERADDRESS}/{name}");
            return result;
        }

        public async Task<bool> UpdateItem(string name, MotherboardDTO item)
        {
            var result = await _controller.PutAsync($"{CONTROLLERADDRESS}/{name}", item);
            return result;
        }
    }
}
