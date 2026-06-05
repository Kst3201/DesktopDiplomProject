using DesktopDiplomProject.Client.Controllers;
using DiplomDataLibrary.PCComponents.DTO;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components
{
    public class GComponentNamedUnit : IGComponentWithType<ComponentNamedUnitDTO>
    {
        private ICommController _controller;

        public ComponentUnitTypes UnitType { get; set; }

        public async Task<IEnumerable<ComponentNamedUnitDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddItem(ComponentNamedUnitDTO item)
        {
            if (item == null) return false;
            item.UnitType = UnitType;
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(ComponentNamedUnitDTO item)
        {
            if (item == null) return false;
            item.UnitType = UnitType;
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(ComponentNamedUnitDTO item)
        {
            if (item == null) return false;
            item.UnitType = UnitType;
            throw new NotImplementedException();
        }

        public GComponentNamedUnit(ICommController controller)
        {
            _controller = controller;
        }
    }
}
