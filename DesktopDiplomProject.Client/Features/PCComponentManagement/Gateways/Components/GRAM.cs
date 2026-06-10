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
        private const string CONTROLLERADDRESS = "api/RAM";
        private ICommController _controller;

        public GRAM(ICommController controller)
        {
            _controller = controller;
        }

        public async Task<bool> AddItem(RAMDTO item)
        {
            var result = await _controller.PostAsync(CONTROLLERADDRESS, item);
            return result;
        }

        public async Task<RAMDTO> GetItem(string name)
        {
            var result = await _controller.GetAsync<RAMDTO>($"{CONTROLLERADDRESS}/{name}");
            return result ?? new RAMDTO(string.Empty, string.Empty, string.Empty, 0, 0, string.Empty);
        }

        public async Task<RAMDTO> GetItemByFullname(string name)
        {
            var result = await _controller.GetAsync<RAMDTO>($"{CONTROLLERADDRESS}/ByFullname/{name}", true);
            return result ?? new RAMDTO(string.Empty, string.Empty, string.Empty, 0, 0, string.Empty);
        }

        public async Task<IEnumerable<RAMDTO>> GetItems()
        {
            var result = await _controller.GetAsync<IEnumerable<RAMDTO>>(CONTROLLERADDRESS);
            return result ?? new List<RAMDTO>();
        }

        public async Task<bool> RemoveItem(string name)
        {
            var result = await _controller.DeleteAsync($"{CONTROLLERADDRESS}/{name}");
            return result;
        }

        public async Task<bool> UpdateItem(string name, RAMDTO item)
        {
            var result = await _controller.PutAsync($"{CONTROLLERADDRESS}/{name}", item);
            return result;
        }
    }
}
