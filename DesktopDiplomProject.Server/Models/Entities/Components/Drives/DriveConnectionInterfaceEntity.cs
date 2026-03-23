using System.ComponentModel.DataAnnotations;

namespace DesktopDiplomProject.Server.Models.Entities.Components.Drives
{
    public class DriveConnectionInterfaceEntity : IEntityWithName
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<DriveEntity> Drives { get; set; } = [];
    }
}
