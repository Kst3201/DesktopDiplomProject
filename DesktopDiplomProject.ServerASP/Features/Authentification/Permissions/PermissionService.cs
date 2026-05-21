
using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Data.Configuration.Authentification;
using DesktopDiplomProject.Server.Models.Entities.Authentification;
using Microsoft.EntityFrameworkCore;

namespace DesktopDiplomProject.ServerASP.Features.Authentification.Permissions
{
    public class PermissionService : IPermissionService
    {
        private enum Actions
        {
            Read = 1,
            Write,
            Add,
            Update,
            Delete
        }

        private UpgradePCApplicationContext _context;

        public PermissionService(UpgradePCApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<IPermission> GetPermissions(int roleID)
        {
            var permissions = GetPermissionDictionary(roleID);
            List<IPermission> result = new List<IPermission>();
            foreach (var kvp in permissions)
            {
                result.Add(GetPermission(kvp.Key, kvp.Value.Select(item => item.ActionPermission).ToList()));
            }
            return result;
        }

        private Dictionary<string, List<RolePermissionsEntity>> GetPermissionDictionary(int roleID)
        {
            var permissions = _context.RolePermissions
                .Include(x => x.Role)
                .Include(x => x.DomainPermission)
                .Include(x => x.ActionPermission)
                .Where(x => x.RoleID.Equals(roleID));
            Dictionary<string, List<RolePermissionsEntity>> permissionsDict = new Dictionary<string, List<RolePermissionsEntity>>();
            foreach (var permission in permissions)
            {
                if (permissionsDict.TryGetValue(permission.DomainPermission.Name, out var list) && list != null)
                {
                    list.Add(permission);
                }
                else
                {
                    permissionsDict[permission.DomainPermission.Name] = new List<RolePermissionsEntity> { permission };
                }
            }
            return permissionsDict;
        }

        private IPermission GetPermission(string domain, IList<ActionPermissionEntity> permissionActions)
        {
            Permission permission = new Permission(domain);
            foreach (var action in permissionActions)
            {
                if (Enum.IsDefined(typeof(Actions), action.ID))
                {
                    Actions act = (Actions)action.ID;
                    SetPermission(permission, act);
                }
            }
            return permission;
        }

        private void SetPermission(Permission permission, Actions action)
        {
            switch (action)
            {
                case Actions.Read:
                    {
                        permission.CanRead = true;
                        break;
                    }
                case Actions.Write:
                    {
                        permission.CanAdd = true;
                        permission.CanUpdate = true;
                        permission.CanDelete = true;
                        break;
                    }
                case Actions.Add:
                    {
                        permission.CanAdd = true;
                        break;
                    }
                case Actions.Update:
                    {
                        permission.CanUpdate = true;
                        break;
                    }
                case Actions.Delete:
                    {
                        permission.CanDelete = true;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
