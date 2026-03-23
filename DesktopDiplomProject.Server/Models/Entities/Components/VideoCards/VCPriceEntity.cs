namespace DesktopDiplomProject.Server.Models.Entities.Components.VideoCards
{
    public class VCPriceEntity : DoubleValueScoredEntity
    {
        public int ID { get; set; }

        public List<VideoCardEntity> VideoCards { get; set; } = [];
    }
}
