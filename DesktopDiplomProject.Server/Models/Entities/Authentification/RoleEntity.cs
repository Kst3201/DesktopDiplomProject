using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Models.Entities.Authentification
{
    public class RoleEntity
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;

        public List<UserEntity> Users { get; set; } = [];
    }
}
