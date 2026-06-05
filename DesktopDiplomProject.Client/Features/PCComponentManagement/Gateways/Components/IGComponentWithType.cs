using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components
{
    public interface IGComponentWithType<T> : IGComponent<T> where T : class
    {
        ComponentUnitTypes UnitType { get; set; }
    }
}
