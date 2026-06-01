namespace DiplomDataLibrary.PCComponents.DTO
{
    public class RAMDTO : BaseComponentDTO
    {
        public RAMTypeDTO RAMType { get; set; }
        public int SingleModuleCapacity { get; set; } = 0;
        public int CountModules { get; set; } = 0;
        public int Frequency { get; set; } = 0;

        public RAMDTO(string name, string manufacturer, string model, double price, double totalScore, RAMTypeDTO ramType) 
            : base(name, manufacturer, model, price, totalScore)
        {
            RAMType = ramType;
        }
    }
}
