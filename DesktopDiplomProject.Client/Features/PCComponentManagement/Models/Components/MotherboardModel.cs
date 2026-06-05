using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components
{
    public class MotherboardModel
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public string Socket { get; set; }
        public string RAMType { get; set; }
        public int RAMCountSlots { get; set; }
        public int MaxRAMValue { get; set; }
        public int MaxRAMFrequency { get; set; }
        public string PCIEInterface { get; set; }
        public int CountPCIEX16Slots { get; set; }
        public int CountM2Slots { get; set; }
        public int CountSATASlots { get; set; }
        public double Price { get; set; }
        public double TotalScore { get; set; }

        public MotherboardModel()
        {
            Name = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            Size = string.Empty;
            Socket = string.Empty;
            RAMType = string.Empty;
            RAMCountSlots = 0;
            MaxRAMValue = 0;
            MaxRAMFrequency = 0;
            PCIEInterface = string.Empty;
            CountPCIEX16Slots = 0;
            CountM2Slots = 0;
            CountSATASlots = 0;
            Price = 0;
            TotalScore = 0;
        }
    }
}
