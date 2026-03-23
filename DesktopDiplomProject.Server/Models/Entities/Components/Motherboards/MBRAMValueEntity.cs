namespace DesktopDiplomProject.Server.Models.Entities.Components.Motherboards
{
    public class MBRAMValueEntity : IntValueScoredEntity
    {
        public int ID { get; set; }

        public List<MotherboardEntity> Motherboards { get; set; } = [];
    }
}
