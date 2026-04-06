using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using DesktopDiplomProject.Server.Models.Entities.PersonalComputers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Models.Entities.Components.CPUs
{
    public class CPUEntity : IComponentEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Manufacturer { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;

        public int SocketID { get; set; }
        public CPUSocketEntity Socket { get; set; } = null!;

        public int CountCoresID { get; set; }
        public CPUCoreCountEntity CountCores { get; set; } = null!;

        public int CountThreadsID { get; set; }
        public CPUThreadsCountEntity CountThreads { get; set; } = null!;

        public int BaseFrequencyID { get; set; }
        public CPUBaseFrequencyEntity BaseFrequency { get; set; } = null!;

        public int RAMTypeID { get; set; }
        public RAMTypeEntity RAMType { get; set; } = null!;

        public int PriceID { get; set; }
        public CPUPriceEntity Price { get; set; } = null!;

        public List<PCEntity> PCs { get; set; } = [];
    }
}
