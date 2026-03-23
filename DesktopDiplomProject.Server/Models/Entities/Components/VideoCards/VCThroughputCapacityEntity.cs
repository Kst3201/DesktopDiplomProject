namespace DesktopDiplomProject.Server.Models.Entities.Components.VideoCards
{
    public class VCThroughputCapacityEntity : IntValueScoredEntity
    {
        public int ID { get; set; }

        public List<VideoCardEntity> VideoCards { get; set; } = [];
    }
}
