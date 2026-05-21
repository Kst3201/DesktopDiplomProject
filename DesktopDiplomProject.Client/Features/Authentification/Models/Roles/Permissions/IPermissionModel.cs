using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.Models.Roles.Competitions
{
    public interface IPermissionModel
    {
        string Domain { get; }


        bool CanRead { get; }
        bool CanAdd { get; }
        bool CanRemove { get; }
        bool CanUpdate { get; }
    }
}
