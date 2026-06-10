namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models
{
    public class VideoCardModel : BaseComponentModel
    {
        public string GPU { get; set; }
        public string PCIEInterface { get; set; }
        public int CountPCIELines { get; set; }
        public int RecommendedBlockPower { get; set; }
        public int CountPinsAdditionalPower { get; set; }
        public int CapacityVideoMemory { get; set; }
        public int MaxThroughputCapacity { get; set; }
        public int MemoryFrequency { get; set; }
        public int CountMonitors { get; set; }
        

        public VideoCardModel()
        {
            GPU = string.Empty;
            PCIEInterface = string.Empty;
            CountPCIELines = 0;
            RecommendedBlockPower = 0;
            CountPinsAdditionalPower = 0;
            CapacityVideoMemory = 0;
            MaxThroughputCapacity = 0;
            MemoryFrequency = 0;
            CountMonitors = 0;
        }

        public VideoCardModel(VideoCardModel copy) : base(copy)
        {
            GPU = copy.GPU;
            PCIEInterface = copy.PCIEInterface;
            CountPCIELines = copy.CountPCIELines;
            RecommendedBlockPower = copy.RecommendedBlockPower;
            CountPinsAdditionalPower = copy.CountPinsAdditionalPower;
            CapacityVideoMemory = copy.CapacityVideoMemory;
            MaxThroughputCapacity = copy.MaxThroughputCapacity;
            MemoryFrequency = copy.MemoryFrequency;
            CountMonitors = copy.CountMonitors;
        }

        public override object Clone()
        {
            return new VideoCardModel(this);
        }
    }
}
