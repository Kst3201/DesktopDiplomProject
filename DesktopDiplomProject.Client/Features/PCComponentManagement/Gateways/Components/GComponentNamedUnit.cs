using DesktopDiplomProject.Client.Controllers;
using DiplomDataLibrary.PCComponents.DTO;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components
{
    public class GComponentNamedUnit : IGComponent<ComponentNamedUnitDTO>
    {
        private string _controllerAddr;
        private ICommController _controller;

        public string ControllerAddress => $"api/{_controllerAddr}";

        public GComponentNamedUnit(ICommController controller)
        {
            _controllerAddr = string.Empty;
            _controller = controller;
        }

        public void SetUnit(ComponentUnitTypes unitType)
        {
            switch (unitType)
            {
                case ComponentUnitTypes.Socket:
                    {
                        _controllerAddr = "Socket";
                        break;
                    }
                case ComponentUnitTypes.MotherboardSize:
                    {
                        _controllerAddr = "MotherboardSize";
                        break;
                    }
                case ComponentUnitTypes.DriveConnectionInterface:
                    {
                        _controllerAddr = "DriveConnectionInterface";
                        break;
                    }
                case ComponentUnitTypes.PCIEInterface:
                    {
                        _controllerAddr = "PCIEInterface";
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(unitType));
            }
        }

        public async Task<bool> AddItem(ComponentNamedUnitDTO item)
        {
            var result = await _controller.PostAsync(ControllerAddress, item);
            return result;
        }

        public async Task<ComponentNamedUnitDTO> GetItem(string name)
        {
            var result = await _controller.GetAsync<ComponentNamedUnitDTO>($"{ControllerAddress}/{name}");
            return result ?? new ComponentNamedUnitDTO(string.Empty);
        }

        public async Task<ComponentNamedUnitDTO> GetItemByFullname(string name)
        {
            var result = await _controller.GetAsync<ComponentNamedUnitDTO>($"{ControllerAddress}/ByFullname/{name}");
            return result ?? new ComponentNamedUnitDTO(string.Empty);
        }

        public async Task<IEnumerable<ComponentNamedUnitDTO>> GetItems()
        {
            var result = await _controller.GetAsync<IEnumerable<ComponentNamedUnitDTO>>(ControllerAddress);
            return result ?? new List<ComponentNamedUnitDTO>();
        }

        public async Task<bool> RemoveItem(string name)
        {
            var result = await _controller.DeleteAsync($"{ControllerAddress}/{name}");
            return result;
        }

        public async Task<bool> UpdateItem(string name, ComponentNamedUnitDTO item)
        {
            var result = await _controller.PutAsync($"{ControllerAddress}/{name}", item);
            return result;
        }
    }
}
