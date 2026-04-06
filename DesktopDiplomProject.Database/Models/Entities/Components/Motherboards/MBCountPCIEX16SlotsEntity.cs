namespace DesktopDiplomProject.Server.Models.Entities.Components.Motherboards
{
    public class MBCountPCIEX16SlotsEntity : IntValueScoredEntity
    {
        public int ID { get; set; }

        public List<MotherboardEntity> Motherboards { get; set; } = [];
    }
}
