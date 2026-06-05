namespace DiplomDataLibrary.PCComponents.DTO.Components
{
    public class RAMDTO : BaseComponentDTO
    {
        public string RAMType { get; set; }
        public int SingleModuleCapacity { get; set; } = 0;
        public int CountModules { get; set; } = 0;
        public int Frequency { get; set; } = 0;

        public RAMDTO(string name, string manufacturer, string model, double price, double totalScore, string ramType) 
            : base(name, manufacturer, model, price, totalScore)
        {
            RAMType = ramType;
        }
    }
}
