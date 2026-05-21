namespace DesktopDiplomProject.Server.Models.Entities.Authentification
{
    public class RolePermissionsEntity
    {
        public int ID { get; set; }

        public int RoleID { get; set; }
        public RoleEntity Role { get; set; } = null!;

        public int DomainPermissionID { get; set; }
        public DomainPermissionEntity DomainPermission { get; set; } = null!;

        public int ActionPermissionID { get; set; }
        public ActionPermissionEntity ActionPermission { get; set; } = null!;
    }
}
