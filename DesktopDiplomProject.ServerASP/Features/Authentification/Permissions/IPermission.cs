namespace DesktopDiplomProject.ServerASP.Features.Authentification.Permissions
{
    public interface IPermission
    {
        string Domain { get; }

        bool CanRead { get; set; }
        bool CanAdd { get; set; }
        bool CanUpdate { get; set; }
        bool CanDelete { get; set; }

        int GetPermissionsInt();

    }
}
