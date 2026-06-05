using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCComponents.DTO.Components
{
    public class BaseComponentUnitDTO : BaseComponentNamedUnitDTO
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double TotalScore { get; set; }

        public BaseComponentUnitDTO(string name, string manufacturer, string model, double totalScore) : base(name)
        {
            Manufacturer = manufacturer;
            Model = model;
            TotalScore = totalScore;
        }
    }
}
