using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Models.Components
{
    class TestGPUModel
    {
        public string CapacityVideoMemory { get; set; }
        public string MonitorCount {  get; set; }
        public string MemoryFrequency { get; set; }
        public string Price { get; set; }
        public string CapacityThroughput { get; set; }

        public TestGPUModel()
        {
            CapacityVideoMemory = string.Empty;
            MonitorCount = string.Empty;
            MemoryFrequency = string.Empty;
            Price = string.Empty;
            CapacityThroughput = string.Empty;
        }
    }
}
