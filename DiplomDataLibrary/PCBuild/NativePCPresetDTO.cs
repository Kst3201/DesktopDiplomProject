using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCBuild
{
    public class NativePCPresetDTO : IPCPresetDTO
    {
        public string Name { get; set; } = string.Empty;
        public double CPUCoeff { get; set; } = 1;
        public double DriveCoeff { get; set; } = 1;
        public double MotherboardCoeff { get; set; } = 1;
        public double RAMCoeff { get; set; } = 1;
        public double VideoCardCoeff { get; set; } = 1;

        public NativePCPresetDTO() { }
    }
}
