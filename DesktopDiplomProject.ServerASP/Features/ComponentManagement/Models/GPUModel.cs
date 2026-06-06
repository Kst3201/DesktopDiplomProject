namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models
{
    public class GPUModel : BaseComponentUnitModel
    {
        public int BaseFrequency { get; set; }
        public int CountUniversalProcessors { get; set; }
        public int CountTexturerBlocks { get; set; }
        public int CountRasterizationBlocks { get; set; }
        public int CountRTCores { get; set; }
        public int CountTensorCores { get; set; }

        public GPUModel()
        {
            BaseFrequency = 0;
            CountUniversalProcessors = 0;
            CountTexturerBlocks = 0;
            CountRasterizationBlocks = 0;
            CountRTCores = 0;
            CountTensorCores = 0;
        }
    }
}
