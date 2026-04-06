using DesktopDiplomProject.Server.Models.Entities.PersonalComputers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Models.Entities.Components.Drives
{
    public class DriveEntity : IComponentEntity
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Manufacturer { get; set; } = string.Empty;

        [Required]
        public string Model { get; set; } = string.Empty;

        public int CapacityID { get; set; }
        public DriveCapacityEntity Capacity { get; set; } = null!;

        public int SpeedDataTransferID { get; set; }
        public DriveSpeedDataTransferEntity SpeedDataTransfer { get; set; } = null!;

        public int ConnectorInterfaceID { get; set; }
        public DriveConnectionInterfaceEntity ConnectorInterface { get; set; } = null!;

        public int PriceID { get; set; }
        public DrivePriceEntity Price { get; set; } = null!;

        public List<PCEntity> PCs { get; set; } = [];
    }
}
