namespace DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs
{
    public class GPUCountTexturerBlocksEntity : IntValueScoredEntity
    {
        public int ID { get; set; }

        public List<GPUEntity> GPUs { get; set; } = [];
    }
}
