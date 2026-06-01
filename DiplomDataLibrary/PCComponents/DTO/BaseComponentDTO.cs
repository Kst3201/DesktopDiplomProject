using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCComponents.DTO
{
    public abstract class BaseComponentDTO : BaseComponentUnitDTO
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public double TotalScore { get; set; }

        public BaseComponentDTO(string name, string manufacturer, string model, double price, double totalScore) : base(name)
        {
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            TotalScore = totalScore;
        }
    }
}
