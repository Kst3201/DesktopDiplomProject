using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Models.Entities.Components.RAMs
{
    public class RAMTypeEntity : ScoredEntity, IEntityWithName
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public List<CPUEntity> CPUs { get; set; } = [];
        public List<MotherboardEntity> Motherboards { get; set; } = [];
        public List<RAMEntity> RAMs { get; set; } = [];
    }
}
