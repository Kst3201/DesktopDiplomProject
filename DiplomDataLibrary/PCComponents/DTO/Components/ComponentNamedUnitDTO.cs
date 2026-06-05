using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCComponents.DTO.Components
{
    public class ComponentNamedUnitDTO : BaseComponentNamedUnitDTO
    {
        public ComponentUnitTypes UnitType { get; set; }

        public ComponentNamedUnitDTO(string name, ComponentUnitTypes unitType) : base(name)
        {
            UnitType = unitType;
        }
    }
}
