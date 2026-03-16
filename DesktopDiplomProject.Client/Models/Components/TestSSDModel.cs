using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Models.Components
{
    class TestSSDModel
    {
        public string Capacity { get; set; }
        public string ConnectionInterface { get; set; }
        public string Price { get; set; }
        public string SpeedDataTransfer { get; set; }

        public TestSSDModel()
        {
            Capacity = string.Empty;
            ConnectionInterface = string.Empty;
            Price = string.Empty;
            SpeedDataTransfer = string.Empty;
        }
    }
}
