using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCBuild
{
    public interface IPCPresetDTO
    {
        string Name { get; set; }
        double CPUCoeff { get; set; }
        double DriveCoeff { get; set; }
        double MotherboardCoeff { get; set; }
        double RAMCoeff { get; set; }
        double VideoCardCoeff { get; set; }
    }
}
