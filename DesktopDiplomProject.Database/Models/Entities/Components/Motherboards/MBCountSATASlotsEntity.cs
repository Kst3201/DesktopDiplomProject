namespace DesktopDiplomProject.Server.Models.Entities.Components.Motherboards
{
    public class MBCountSATASlotsEntity : IntValueScoredEntity
    {
        public int ID { get; set; }

        public List<MotherboardEntity> Motherboards { get; set; } = [];
    }
}
