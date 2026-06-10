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
        private const string CONTROLLERADDRESS = "api/Drive";
        private ICommController _controller;

        public GDrive(ICommController controller)
        {
            _controller = controller;
        }

        public async Task<bool> AddItem(DriveDTO item)
        {
            var result = await _controller.PostAsync(CONTROLLERADDRESS, item);
            return result;
        }

        public async Task<IEnumerable<DriveDTO>> GetItems()
        {
            var result = await _controller.GetAsync<IEnumerable<DriveDTO>>(CONTROLLERADDRESS);
            return result ?? new List<DriveDTO>();
        }

        public async Task<bool> RemoveItem(string name)
        {
            var result = await _controller.DeleteAsync($"{CONTROLLERADDRESS}/{name}");
            return result;
        }

        public async Task<bool> UpdateItem(string name, DriveDTO item)
        {
            var result = await _controller.PutAsync($"{CONTROLLERADDRESS}/{name}", item);
            return result;
        }

        public async Task<DriveDTO> GetItem(string name)
        {
            var result = await _controller.GetAsync<DriveDTO>($"{CONTROLLERADDRESS}/{name}");
            return result ?? new DriveDTO(string.Empty, string.Empty, string.Empty, 0, 0, string.Empty);
        }

        public async Task<DriveDTO> GetItemByFullname(string name)
        {
            var result = await _controller.GetAsync<DriveDTO>($"{CONTROLLERADDRESS}/ByFullname/{name}", true);
            return result ?? new DriveDTO(string.Empty, string.Empty, string.Empty, 0, 0, string.Empty);
        }
    }
}
