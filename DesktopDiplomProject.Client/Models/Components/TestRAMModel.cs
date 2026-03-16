using DesktopDiplomProject.Client.ViewModels.Windows.Components.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Models.Components
{
    class TestRAMModel
    {
        public string CountModules { get; set; }
        public string Frequency { get; set; }
        public string Price { get; set; }
        public string CapacitySingleModule { get; set; }

        public TestRAMModel()
        {
            CountModules = string.Empty;
            Frequency = string.Empty;
            Price = string.Empty;
            CapacitySingleModule = string.Empty;
        }
    }
}
