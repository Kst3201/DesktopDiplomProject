using DesktopDiplomProject.Database.Models.Entities.Authentification;
using DesktopDiplomProject.Server.Models.Entities.PersonalComputers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Models.Entities.Authentification
{
    public class UserEntity
    {
        public int ID { get; set; }
        [Required]
        public string Login { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;

        public int RoleID { get; set; }
        public RoleEntity Role { get; set; } = null!;

        public List<PCEntity> PCs { get; set; } = [];
        public List<RefreshTokenEntity> RefreshTokens { get; set; } = [];
    }
}
