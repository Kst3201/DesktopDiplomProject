using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components
{
    public class VideoCardModel
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string GPU { get; set; }
        public string PCIEInterface { get; set; }
        public int CountPCIELines { get; set; }
        public int RecommendedBlockPower { get; set; }
        public int CountPinsAdditionalPower { get; set; }
        public int CapacityVideoMemory { get; set; }
        public int MaxThroughputCapacity { get; set; }
        public int MemoryFrequency { get; set; }
        public int CountMonitors { get; set; }
        public double Price { get; set; }
        public double TotalScore { get; set; }

        public VideoCardModel()
        {
            Name = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            GPU = string.Empty;
            PCIEInterface = string.Empty;
            CountPCIELines = 0;
            RecommendedBlockPower = 0;
            CountPinsAdditionalPower = 0;
            CapacityVideoMemory = 0;
            MaxThroughputCapacity = 0;
            MemoryFrequency = 0;
            CountMonitors = 0;
            Price = 0;
            TotalScore = 0;
        }
    }
}
