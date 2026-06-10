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
        private const string CONTROLLERADDRESS = "api/CPU";
        private ICommController _controller;

        public GCPU(ICommController controller)
        {
            _controller = controller;
        }

        public async Task<bool> AddItem(CPUDTO item)
        {
            var result = await _controller.PostAsync(CONTROLLERADDRESS, item);
            return result;
        }

        public async Task<CPUDTO> GetItem(string name)
        {
            var result = await _controller.GetAsync<CPUDTO>($"{CONTROLLERADDRESS}/{name}");
            return result ?? new CPUDTO(string.Empty, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty);
        }

        public async Task<CPUDTO> GetItemByFullname(string name)
        {
            var result = await _controller.GetAsync<CPUDTO>($"{CONTROLLERADDRESS}/ByFullname/{name}", true);
            return result ?? new CPUDTO(string.Empty, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty);
        }

        public async Task<IEnumerable<CPUDTO>> GetItems()
        {
            var list = await _controller.GetAsync<IEnumerable<CPUDTO>>(CONTROLLERADDRESS);
            return list?.ToList() ?? new List<CPUDTO>();
        }

        public async Task<bool> RemoveItem(string name)
        {
            var result = await _controller.DeleteAsync($"{CONTROLLERADDRESS}/{name}");
            return result;
        }

        public async Task<bool> UpdateItem(string name, CPUDTO item)
        {
            var result = await _controller.PutAsync($"{CONTROLLERADDRESS}/{name}", item);
            return result;
        }
    }
}
