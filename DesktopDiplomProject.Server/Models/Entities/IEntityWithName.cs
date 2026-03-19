using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Models.Entities
{
    internal interface IEntityWithName
    {
        string Name { get; set; }
    }
}
