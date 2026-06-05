using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components
{
    public class CPUModel
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Socket { get; set; }
        public int CountCores { get; set; }
        public int CountThreads { get; set; }
        public int BaseFrequency { get; set; }
        public string RAMType { get; set; }
        public double Price { get; set; }
        public double TotalScore { get; set; }

        public CPUModel()
        {
            Name = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            Socket = string.Empty;
            CountCores = 0;
            CountThreads = 0;
            BaseFrequency = 0;
            RAMType = string.Empty;
            Price = 0;
            TotalScore = 0;
        }
    }
}
