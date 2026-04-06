namespace DesktopDiplomProject.Server.Models.Entities.Components.RAMs
{
    public class RAMSingleModuleCapacityEntity : IntValueScoredEntity
    {
        public int ID { get; set; }

        public List<RAMEntity> RAMs { get; set; } = [];
    }
}
