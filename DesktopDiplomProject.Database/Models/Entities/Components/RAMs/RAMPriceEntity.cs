namespace DesktopDiplomProject.Server.Models.Entities.Components.RAMs
{
    public class RAMPriceEntity : DoubleValueScoredEntity
    {
        public int ID { get; set; }

        public List<RAMEntity> RAMs { get; set; } = [];
    }
}
