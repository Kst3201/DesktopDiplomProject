using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs
{
    public class GPUEntity : IComponentEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Manufacturer { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;

        public int BaseFrequencyID { get; set; }
        public GPUFrequencyEntity BaseFrequency { get; set; } = null!;

        public int CountUniversalProcessorsID { get; set; }
        public GPUCountUniversalProcessorsEntity CountUniversalProcessors { get; set; } = null!;

        public int CountTexturerBlocksID { get; set; }
        public GPUCountTexturerBlocksEntity CountTexturerBlocks { get; set; } = null!;

        public int CountRasterizationBlocksID { get; set; }
        public GPUCountRasterizationBlocksEntity CountRasterizationBlocks { get; set; } = null!;

        public int CountRTCoresID { get; set; }
        public GPUCountRTCoresEntity CountRTCores { get; set; } = null!;

        public int CountTensorCoresID { get; set; }
        public GPUCountTensorCoresEntity CountTensorCores { get; set; } = null!;

        public List<VideoCardEntity> VideoCards { get; set; } = [];
    }
}
