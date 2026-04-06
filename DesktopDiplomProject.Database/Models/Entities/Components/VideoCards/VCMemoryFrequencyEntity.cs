namespace DesktopDiplomProject.Server.Models.Entities.Components.VideoCards
{
    public class VCMemoryFrequencyEntity : IntValueScoredEntity
    {
        public int ID { get; set; }

        public List<VideoCardEntity> VideoCards { get; set; } = [];
    }
}
