using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using DesktopDiplomProject.Server.Models.Entities.PersonalComputers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Models.Entities.Components.Motherboards
{
    public class MotherboardEntity : IComponentEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Manufacturer { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;

        public int SizeID { get; set; }
        public MBSizeEntity Size { get; set; } = null!;

        public int SocketID { get; set; }
        public CPUSocketEntity Socket { get; set; } = null!;

        public int RAMTypeID { get; set; }
        public RAMTypeEntity RAMType { get; set; } = null!;

        public int RAMCountSlotsID { get; set; }
        public MBRAMCountSlotsEntity RAMCountSlots { get; set; } = null!;

        public int MaxRAMValueID { get; set; }
        public MBRAMValueEntity MaxRAMValue { get; set; } = null!;

        public int MaxRAMFrequencyID { get; set; }
        public MBRAMFrequencyEntity MaxRAMFrequency { get; set; } = null!;

        public int PCIEInterfaceID { get; set; }
        public PCIEInterfaceEntity PCIEInterface { get; set; } = null!;

        public int CountPCIEX16SlotsID { get; set; }
        public MBCountPCIEX16SlotsEntity CountPCIEX16Slots { get; set; } = null!;

        public int CountM2SlotsID { get; set; }
        public MBCountM2SlotsEntity CountM2Slots { get; set; } = null!;

        public int CountSATASlotsID { get; set; }
        public MBCountSATASlotsEntity CountSATASlots { get; set; } = null!;

        public int PriceID { get; set; }
        public MBPriceEntity Price { get; set; } = null!;

        public List<PCEntity> PCs { get; set; } = [];
    }
}
