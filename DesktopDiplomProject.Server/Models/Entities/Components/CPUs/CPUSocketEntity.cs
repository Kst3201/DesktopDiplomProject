using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using System.ComponentModel.DataAnnotations;

namespace DesktopDiplomProject.Server.Models.Entities.Components.CPUs
{
    public class CPUSocketEntity : IEntityWithName
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public List<CPUEntity> CPUs { get; set; } = [];
        public List<MotherboardEntity> Motherboards { get; set; } = [];
    }
}
