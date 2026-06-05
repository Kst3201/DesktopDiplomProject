namespace DiplomDataLibrary.PCComponents.DTO.Components
{
    public class MotherboardDTO : BaseComponentDTO
    {
        public string Size { get; set; }
        public string Socket { get; set; }
        public string RAMType { get; set; }
        public int RAMCountSlots { get; set; } = 0;
        public int MaxRAMValue { get; set; } = 0;
        public int MaxRAMFrequency { get; set; } = 0;
        public string PCIEInterface { get; set; }
        public int CountPCIEX16Slots { get; set; } = 0;
        public int CountM2Slots { get; set; } = 0;
        public int CountSATASlots { get; set; } = 0;

        public MotherboardDTO(string name, string manufacturer, string model, double price, double totalScore
            , string size, string socket, string ramType, string pcieInterface)
            : base(name, manufacturer, model, price, totalScore)
        {
            Size = size;
            Socket = socket;
            RAMType = ramType;
            PCIEInterface = pcieInterface;
        }
    }
}
