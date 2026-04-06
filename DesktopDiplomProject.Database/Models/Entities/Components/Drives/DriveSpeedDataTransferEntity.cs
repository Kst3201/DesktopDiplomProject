namespace DesktopDiplomProject.Server.Models.Entities.Components.Drives
{
    public class DriveSpeedDataTransferEntity : IntValueScoredEntity
    {
        public int ID { get; set; }
        public List<DriveEntity> Drives { get; set; } = [];
    }
}
