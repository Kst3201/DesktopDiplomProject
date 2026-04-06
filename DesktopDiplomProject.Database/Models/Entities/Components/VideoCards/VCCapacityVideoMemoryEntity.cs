namespace DesktopDiplomProject.Server.Models.Entities.Components.VideoCards
{
    public class VCCapacityVideoMemoryEntity : IntValueScoredEntity
    {
        public int ID { get; set; }

        public List<VideoCardEntity> VideoCards { get; set; } = [];
    }
}
