using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using System.Net.Sockets;

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

        public RAMModel(RAMModel copy) : base(copy)
        {
            RAMType = copy.RAMType;
            SingleModuleCapacity = copy.SingleModuleCapacity;
            CountModules = copy.CountModules;
            Frequency = copy.Frequency;
        }

        public override object Clone()
        {
            return new RAMModel(this);
        }
    }
}
