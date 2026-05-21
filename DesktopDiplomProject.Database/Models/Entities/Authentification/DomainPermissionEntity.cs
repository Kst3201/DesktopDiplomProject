namespace DesktopDiplomProject.Server.Models.Entities.Authentification
{
    public class DomainPermissionEntity
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public List<RolePermissionsEntity> RolePermissions { get; set; } = [];
    }
}
