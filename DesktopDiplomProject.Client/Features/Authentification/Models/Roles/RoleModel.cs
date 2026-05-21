using DesktopDiplomProject.Client.Features.Authentification.Models.Roles.Competitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.Models.Roles
{
    public class RoleModel : IRoleModel
    {
        public string Name { get; }
        public IReadOnlyDictionary<string, IPermissionModel> Permissions { get; }

        public RoleModel(string name, IEnumerable<IPermissionModel> permissions)
        {
            Name = name;
            Permissions = permissions == null ? new Dictionary<string, IPermissionModel>() : permissions.ToDictionary(item => item.Domain);
        }
    }
}
