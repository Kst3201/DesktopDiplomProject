using DesktopDiplomProject.ServerASP.Features.Assessment.Models;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models
{
    public class CPUModel : BaseComponentModel
    {
        public string Socket { get; set; }
        public int CountCores { get; set; }
        public int CountThreads { get; set; }
        public int BaseFrequency { get; set; }
        public string RAMType { get; set; }

        public CPUModel() : base()
        {
            Socket = string.Empty;
            CountCores = 0;
            CountThreads = 0;
            BaseFrequency = 0;
            RAMType = string.Empty;
        }

        public CPUModel(CPUModel copy) : base(copy)
        {
            Socket = copy.Socket;
            CountCores = copy.CountCores;
            CountThreads = copy.CountThreads;
            BaseFrequency = copy.BaseFrequency;
            RAMType = copy.RAMType;
        }

        public override object Clone()
        {
            return new CPUModel(this);
        }
    }
}
