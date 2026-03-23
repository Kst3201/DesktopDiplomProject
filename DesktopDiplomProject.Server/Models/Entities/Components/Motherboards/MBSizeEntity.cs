using System.ComponentModel.DataAnnotations;

namespace DesktopDiplomProject.Server.Models.Entities.Components.Motherboards
{
    public class MBSizeEntity : IEntityWithName
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public List<MotherboardEntity> Motherboards { get; set; } = [];
    }
}
