namespace DesktopDiplomProject.Server.Models.Entities.Components.RAMs
{
    public class RAMFrequencyEntity : IntValueScoredEntity
    {
        public int ID { get; set; }

        public List<RAMEntity> RAMs { get; set; } = [];
    }
}
