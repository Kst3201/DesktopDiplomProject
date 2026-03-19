using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Models.Entities.Components
{
    internal interface IComponentEntity : IEntityWithName
    {
        string Manufacturer { get; set; }
        string Model { get; set; }
    }
}
