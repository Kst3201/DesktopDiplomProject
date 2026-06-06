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
    }
}
