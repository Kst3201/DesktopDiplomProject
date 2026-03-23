namespace DesktopDiplomProject.Server.Models.Entities.Components.Motherboards
{
    public class MBPriceEntity : DoubleValueScoredEntity
    {
        public int ID { get; set; }

        public List<MotherboardEntity> Motherboards { get; set; } = [];
    }
}
