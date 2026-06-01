using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCComponents.DTO
{
    public abstract class BaseComponentUnitDTO
    {
        public string Name { get; set; }

        public BaseComponentUnitDTO(string name)
        {
            Name = name;
        }
    }
}
