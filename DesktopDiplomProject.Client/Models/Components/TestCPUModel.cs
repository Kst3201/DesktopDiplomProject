using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DesktopDiplomProject.Client.Models.Components
{
    class TestCPUModel
    {
        public string BaseFrequency { get; set; }
        public string CoreCount { get; set; }
        public string Price { get; set; }
        public string Socket { get; set; }
        public string ThreadCount { get; set; }


        public TestCPUModel()
        {
            BaseFrequency = string.Empty;
            CoreCount = string.Empty;
            Price = string.Empty;
            Socket = string.Empty;
            ThreadCount = string.Empty;
        }
    }
}
