namespace DiplomDataLibrary.PCComponents.DTO.Components
{
    public class DriveDTO : BaseComponentDTO
    {
        public int Capacity { get; set; } = 0;
        public int SpeedDataTransfer { get; set; } = 0;
        public string ConnectorInterface { get; set; }

        public DriveDTO(string name, string manufacturer, string model, double price, double totalScore, string connectorInterface)
            : base(name, manufacturer, model, price, totalScore)
        {
            ConnectorInterface = connectorInterface;
        }
    }
}
