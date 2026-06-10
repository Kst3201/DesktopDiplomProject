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
        private const string CONTROLLERADDRESS = "api/GPU";
        private ICommController _controller;

        public GGPU(ICommController controller)
        {
            _controller = controller;
        }

        public async Task<bool> AddItem(GPUDTO item)
        {
            var result = await _controller.PostAsync(CONTROLLERADDRESS, item);
            return result;
        }

        public async Task<GPUDTO> GetItem(string name)
        {
            var result = await _controller.GetAsync<GPUDTO>($"{CONTROLLERADDRESS}/{name}");
            return result ?? new GPUDTO(string.Empty, string.Empty, string.Empty, 0);
        }

        public async Task<GPUDTO> GetItemByFullname(string name)
        {
            var result = await _controller.GetAsync<GPUDTO>($"{CONTROLLERADDRESS}/ByFullname/{name}", true);
            return result ?? new GPUDTO(string.Empty, string.Empty, string.Empty, 0);
        }

        public async Task<IEnumerable<GPUDTO>> GetItems()
        {
            var result = await _controller.GetAsync<IEnumerable<GPUDTO>>(CONTROLLERADDRESS);
            return result ?? new List<GPUDTO>();
        }

        public async Task<bool> RemoveItem(string name)
        {
            var result = await _controller.DeleteAsync($"{CONTROLLERADDRESS}/{name}");
            return result;
        }

        public async Task<bool> UpdateItem(string name, GPUDTO item)
        {
            var result = await _controller.PutAsync($"{CONTROLLERADDRESS}/{name}", item);
            return result;
        }
    }
}
