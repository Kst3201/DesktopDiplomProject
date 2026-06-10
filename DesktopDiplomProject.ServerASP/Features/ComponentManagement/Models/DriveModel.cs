using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using System.Net.Sockets;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models
{
    public class DriveModel : BaseComponentModel
    {
        public int Capacity { get; set; }
        public int SpeedDataTransfer { get; set; }
        public string ConnectorInterface { get; set; }

        public DriveModel() : base()
        {
            Capacity = 0;
            SpeedDataTransfer = 0;
            ConnectorInterface = string.Empty;
        }

        public DriveModel(DriveModel copy) : base(copy)
        {
            Capacity = copy.Capacity;
            SpeedDataTransfer = copy.SpeedDataTransfer;
            ConnectorInterface = copy.ConnectorInterface;
        }

        public override object Clone()
        {
            return new DriveModel(this);
        }
    }
}
