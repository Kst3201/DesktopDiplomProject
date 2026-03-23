namespace DesktopDiplomProject.Server.Models.Entities.Components.Drives
{
    public class DrivePriceEntity : DoubleValueScoredEntity
    {
        public int ID { get; set; }
        public List<DriveEntity> Drives { get; set; } = [];
    }
}
