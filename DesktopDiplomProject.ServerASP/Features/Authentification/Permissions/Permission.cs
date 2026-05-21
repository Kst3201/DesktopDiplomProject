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

        public int GetPermissionsInt() => _vector.Data;
    }
}
