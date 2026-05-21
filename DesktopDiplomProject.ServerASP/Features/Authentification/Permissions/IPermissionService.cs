namespace DesktopDiplomProject.ServerASP.Features.Authentification.Permissions
{
    public interface IPermissionService
    {
        public IEnumerable<IPermission> GetPermissions(int roleID);
    }
}
