namespace DiplomDataLibrary.PCComponents.DTO.Components
{
    public class VideoCardDTO : BaseComponentDTO
    {
        public string GPU { get; set; }
        public string PCIEInterface { get; set; }
        public int CountPCIELines { get; set; } = 0;
        public int RecommendedBlockPower { get; set; } = 0;
        public int CountPinsAdditionalPower { get; set; } = 0;
        public int CapacityVideoMemory { get; set; } = 0;
        public int MaxThroughputCapacity { get; set; } = 0;
        public int MemoryFrequency { get; set; } = 0;
        public int CountMonitors { get; set; } = 0;

        public VideoCardDTO(string name, string manufacturer, string model, double price, double totalScore
            , string gpu, string pcieInterface)
            : base(name, manufacturer, model, price, totalScore)
        {
            GPU = gpu;
            PCIEInterface = pcieInterface;
        }
    }
}
