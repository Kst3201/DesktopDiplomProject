using DesktopDiplomProject.Server.Models.Entities.Authentification;
using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Models.Entities.PersonalComputers
{
    public class PCEntity
    {
        public int ID { get; set; }
        
        public int CPUID { get; set; }
        public CPUEntity CPU { get; set; } = null!;

        public int MotherboardID { get; set; }
        public MotherboardEntity Motherboard { get; set; } = null!;

        public int DriveID { get; set; }
        public DriveEntity Drive { get; set; } = null!;

        public int RAMID { get; set; }
        public RAMEntity RAM { get; set; } = null!;

        public int VideoCardID { get; set; }
        public VideoCardEntity VideoCard { get; set; } = null!;

        public int UserID { get; set; }
        public UserEntity User { get; set; } = null!;

        public DateTime DateCreate { get; set; } = DateTime.Now;
    }
}
