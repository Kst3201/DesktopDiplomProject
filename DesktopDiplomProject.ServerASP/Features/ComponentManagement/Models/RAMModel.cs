namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models
{
    public class RAMModel : BaseComponentModel
    {
        public string RAMType { get; set; }
        public int SingleModuleCapacity { get; set; }
        public int CountModules { get; set; }
        public int Frequency { get; set; }

        public RAMModel()
        {
            RAMType = string.Empty;
            SingleModuleCapacity = 0;
            CountModules = 0;
            Frequency = 0;
        }
    }
}
