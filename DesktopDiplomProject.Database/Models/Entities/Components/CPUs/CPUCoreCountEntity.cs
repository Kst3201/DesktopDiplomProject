namespace DesktopDiplomProject.Server.Models.Entities.Components.CPUs
{
    public class CPUCoreCountEntity : IntValueScoredEntity
    {
        public int ID { get; set; }
        public List<CPUEntity> CPUs { get; set; } = [];

    }
}
