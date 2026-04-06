using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using System.ComponentModel.DataAnnotations;

namespace DesktopDiplomProject.Server.Models.Entities.Components.VideoCards
{
    public class PCIEInterfaceEntity : IEntityWithName
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<MotherboardEntity> Motherboards { get; set; } = [];
        public List<VideoCardEntity> VideoCards { get; set; } = [];
    }
}
