namespace DesktopDiplomProject.Server.Models.Entities.Components.Motherboards
{
    public class MBRAMCountSlotsEntity : IntValueScoredEntity
    {
        public int ID { get; set; }

        public List<MotherboardEntity> Motherboards { get; set; } = [];
    }
}
