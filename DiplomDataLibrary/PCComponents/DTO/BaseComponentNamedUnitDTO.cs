using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCComponents.DTO
{
    public class BaseComponentNamedUnitDTO
    {
        public string Name { get; set; }

        public BaseComponentNamedUnitDTO(string name)
        {
            Name = name;
        }
    }
}
