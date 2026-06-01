namespace DiplomDataLibrary.PCComponents.DTO
{
    public class GPUDTO : BaseComponentDTO
    {
        public int BaseFrequency { get; set; } = 0;
        public int CountUniversalProcessors { get; set; } = 0;
        public int CountTexturerBlocks { get; set; } = 0;
        public int CountRasterizationBlocks { get; set; } = 0;
        public int CountRTCores { get; set; } = 0;
        public int CountTensorCores { get; set; } = 0;

        public GPUDTO(string name, string manufacturer, string model, double price, double totalScore) : base(name, manufacturer, model, price, totalScore) { }
    }
}
