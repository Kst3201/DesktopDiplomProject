using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components
{
    public class RAMModel
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string RAMType { get; set; }
        public int SingleModuleCapacity { get; set; }
        public int CountModules { get; set; }
        public int Frequency { get; set; }
        public double Price { get; set; }
        public double TotalScore { get; set; }

        public RAMModel()
        {
            Name = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            RAMType = string.Empty;
            SingleModuleCapacity = 0;
            CountModules = 0;
            Frequency = 0;
            Price = 0;
            TotalScore = 0;
        }
    }
}
