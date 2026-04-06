namespace DesktopDiplomProject.Server.Models.Entities.Components.CPUs
{
    public class CPUPriceEntity : DoubleValueScoredEntity
    {
        public int ID { get; set; }
        public List<CPUEntity> CPUs { get; set; } = [];
    }
}
