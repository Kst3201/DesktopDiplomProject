using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components
{
    public class GPUModel
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int BaseFrequency { get; set; }
        public int CountUniversalProcessors { get; set; }
        public int CountTexturerBlocks { get; set; }
        public int CountRasterizationBlocks { get; set; }
        public int CountRTCores { get; set; }
        public int CountTensorCores { get; set; }
        public double TotalScore { get; set; }

        public GPUModel()
        {
            Name = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            BaseFrequency = 0;
            CountUniversalProcessors = 0;
            CountTexturerBlocks = 0;
            CountRasterizationBlocks = 0;
            CountRTCores = 0;
            CountTensorCores = 0;
            TotalScore = 0;
        }
    }
}
