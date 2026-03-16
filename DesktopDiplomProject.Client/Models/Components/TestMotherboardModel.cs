using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DesktopDiplomProject.Client.Models.Components
{
    class TestMotherboardModel
    {
        public string CountM2Slots { get; set; }
        public string CountPCIEX16Slots { get; set; }
        public string CountSATASlots { get; set; }
        public string Price { get; set; }
        public string RAMFrequency { get; set; }
        public string CountRAMSlots { get; set; }
        public string ValueRAM { get; set; }
        public string Size { get; set; }

        public TestMotherboardModel()
        {
            CountM2Slots = string.Empty;
            CountPCIEX16Slots = string.Empty;
            CountSATASlots = string.Empty;
            Price = string.Empty;
            RAMFrequency = string.Empty;
            CountRAMSlots = string.Empty;
            ValueRAM = string.Empty;
            Size = string.Empty;
        }
    }
}
