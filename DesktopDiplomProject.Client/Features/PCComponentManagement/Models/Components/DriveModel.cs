using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components
{
    public class DriveModel
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int SpeedDataTransfer { get; set; }
        public string ConnectorInterface { get; set; }
        public double Price { get; set; }
        public double TotalScore { get; set; }
        
        public DriveModel()
        {
            Name = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            Capacity = 0;
            SpeedDataTransfer = 0;
            ConnectorInterface = string.Empty;
            Price = 0;
            TotalScore = 0;
        }
    }
}
