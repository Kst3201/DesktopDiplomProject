namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models
{
    public class MotherboardModel : BaseComponentModel
    {
        public string Size { get; set; }
        public string Socket { get; set; }
        public string RAMType { get; set; }
        public string PCIEInterface { get; set; }
        public int RAMCountSlots { get; set; }
        public int MaxRAMValue { get; set; }
        public int MaxRAMFrequency { get; set; }
        public int CountPCIEX16Slots { get; set; }
        public int CountM2Slots { get; set; }
        public int CountSATASlots { get; set; }

        public MotherboardModel() : base()
        {
            Size = string.Empty;
            Socket = string.Empty;
            RAMType = string.Empty;
            PCIEInterface = string.Empty;
            RAMCountSlots = 0;
            MaxRAMValue = 0;
            MaxRAMFrequency = 0;
            CountPCIEX16Slots = 0;
            CountM2Slots = 0;
            CountSATASlots = 0;
        }
    }
}
