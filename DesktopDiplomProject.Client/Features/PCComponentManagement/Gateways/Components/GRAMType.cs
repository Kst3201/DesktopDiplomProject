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
        private const string CONTROLLERADDRESS = "api/RAMType";
        private ICommController _controller;

        public GRAMType(ICommController controller)
        {
            _controller = controller;
        }

        public async Task<bool> AddItem(RAMTypeDTO item)
        {
            var result = await _controller.PostAsync(CONTROLLERADDRESS, item);
            return result;
        }

        public async Task<RAMTypeDTO> GetItem(string name)
        {
            var result = await _controller.GetAsync<RAMTypeDTO>($"{CONTROLLERADDRESS}/{name}");
            return result ?? new RAMTypeDTO(string.Empty, 0, 0, 0, 0, 0);
        }

        public async Task<IEnumerable<RAMTypeDTO>> GetItems()
        {
            var result = await _controller.GetAsync<IEnumerable<RAMTypeDTO>>(CONTROLLERADDRESS);
            return result ?? new List<RAMTypeDTO>();
        }

        public async Task<bool> RemoveItem(string name)
        {
            var result = await _controller.DeleteAsync($"{CONTROLLERADDRESS}/{name}");
            return result;
        }

        public async Task<bool> UpdateItem(string name, RAMTypeDTO item)
        {
            var result = await _controller.PutAsync($"{CONTROLLERADDRESS}/{name}", item);
            return result;
        }
    }
}
