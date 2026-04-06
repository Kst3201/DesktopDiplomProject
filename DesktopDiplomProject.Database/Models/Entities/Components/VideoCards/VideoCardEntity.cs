using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs;
using DesktopDiplomProject.Server.Models.Entities.PersonalComputers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Models.Entities.Components.VideoCards
{
    public class VideoCardEntity : IComponentEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Manufacturer { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;

        public int GPUID { get; set; }
        public GPUEntity GPU { get; set; } = null!;

        public int PCIEInterfaceID { get; set; }
        public PCIEInterfaceEntity PCIEInterface { get; set; } = null!;

        [Required]
        public int CountPCIELines { get; set; }
        [Required]
        public int RecommendedBlockPower { get; set; }
        [Required]
        public int CountPinsAdditionalPower { get; set; }

        public int CapacityVideoMemoryID { get; set; }
        public VCCapacityVideoMemoryEntity CapacityVideoMemory { get; set; } = null!;

        public int MaxThroughputCapacityID { get; set; }
        public VCThroughputCapacityEntity MaxThroughputCapacity { get; set; } = null!;

        public int MemoryFrequencyID { get; set; }
        public VCMemoryFrequencyEntity MemoryFrequency { get; set; } = null!;

        public int CountMonitorsID { get; set; }
        public VCCountMonitorsEntity CountMonitors { get; set; } = null!;

        public int PriceID { get; set; }
        public VCPriceEntity Price { get; set; } = null!;

        public List<PCEntity> PCs { get; set; } = [];
    }
}
