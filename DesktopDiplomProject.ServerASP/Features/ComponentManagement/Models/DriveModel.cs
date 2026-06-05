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
    }
}
