using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCComponents.DTO.Components
{

    public abstract class BaseComponentDTO : BaseComponentUnitDTO
    {
        public double Price { get; set; }

        public BaseComponentDTO(string name, string manufacturer, string model, double price, double totalScore) 
            : base(name, manufacturer, model, totalScore)
        {
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
        }
    }
}
