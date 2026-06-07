using DiplomDataLibrary.Authentification.DTO;
using System.Collections.Specialized;

namespace DesktopDiplomProject.ServerASP.Features.Authentification.Permissions
{
    public class Permission : IPermission
    {

        private string _domain;
        private BitVector32 _vector;

        public string Domain => _domain;

        public bool CanRead
        {
            get => _vector[(int)PermissionAction.Read];
            set => _vector[(int)PermissionAction.Read] = value;
        }

        public bool CanAdd
        {
            get => _vector[(int)PermissionAction.Add];
            set => _vector[(int)PermissionAction.Add] = value;
        }

        public bool CanUpdate
        {
            get => _vector[(int)PermissionAction.Update];
            set => _vector[(int)PermissionAction.Update] = value;
        }

        public bool CanDelete
        {
            get => _vector[(int)PermissionAction.Delete];
            set => _vector[(int)PermissionAction.Delete] = value;
        }

        public Permission(string domain)
        {
            _domain = domain;
            _vector = new BitVector32(0);
        }

        public Permission(string domain, int permissions)
        {
            _domain = domain;
            _vector = new BitVector32(permissions);
        }

        public int GetPermissionsInt() => _vector.Data;

        public void SetPermissionsInt(int permissionsInt)
        {
            _vector = new BitVector32(permissionsInt);
        }

        public IEnumerable<PermissionAction> GetPermissions()
        {
            var result = new List<PermissionAction>();
            foreach (var item in Enum.GetValues<PermissionAction>())
            {
                if (_vector[(int)item])
                    result.Add(item);
            }
            return result;
        }
    }
}
