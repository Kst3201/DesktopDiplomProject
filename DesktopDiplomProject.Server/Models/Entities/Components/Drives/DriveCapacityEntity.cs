namespace DesktopDiplomProject.Server.Models.Entities.Components.Drives
{
    public class DriveCapacityEntity : IntValueScoredEntity
    {
        public int ID { get; set; }

        public List<DriveEntity> Drives { get; set; } = [];
    }
}
