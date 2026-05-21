namespace DesktopDiplomProject.Server.Models.Entities.Authentification
{
    public class ActionPermissionEntity
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public List<RolePermissionsEntity> RoleRermissions { get; set; } = [];
    }
}
