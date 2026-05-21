using DesktopDiplomProject.Client.Features.Authentification.Models.Roles.Competitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.Models.Roles
{
    public interface IRoleModel
    {
        string Name { get; }

        IReadOnlyDictionary<string, IPermissionModel> Permissions { get; }

    }
}
