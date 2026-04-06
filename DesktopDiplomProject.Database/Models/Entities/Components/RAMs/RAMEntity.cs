using DesktopDiplomProject.Server.Models.Entities.PersonalComputers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Models.Entities.Components.RAMs
{
    public class RAMEntity : IComponentEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Manufacturer { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;

        public int RAMTypeID { get; set; }
        public RAMTypeEntity RAMType { get; set; } = null!;

        public int SingleModuleCapacityID { get; set; }
        public RAMSingleModuleCapacityEntity SingleModuleCapacity { get; set; } = null!;

        public int CountModulesID { get; set; }
        public RAMCountModulesEntity CountModules { get; set; } = null!;

        public int FrequencyID { get; set; }
        public RAMFrequencyEntity Frequency { get; set; } = null!;

        public int PriceID { get; set; }
        public RAMPriceEntity Price { get; set; } = null!;

        public List<PCEntity> PCs { get; set; } = [];
    }
}
