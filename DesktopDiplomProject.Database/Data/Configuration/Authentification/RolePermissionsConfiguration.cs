using DesktopDiplomProject.Server.Models.Entities.Authentification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Authentification
{
    public class RolePermissionsConfiguration : IEntityTypeConfiguration<RolePermissionsEntity>
    {
        public void Configure(EntityTypeBuilder<RolePermissionsEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            builder.HasIndex(x => new { x.RoleID, x.DomainPermissionID, x.ActionPermissionID })
                .IsUnique()
                .HasDatabaseName("IX_RolePermissions_Role_DomainPermission_ActionPermission");

            builder.HasOne(x => x.Role)
                .WithMany(y => y.Permissions)
                .HasForeignKey(x => x.RoleID)
                .IsRequired();

            builder.HasOne(x => x.DomainPermission)
                .WithMany(y => y.RolePermissions)
                .HasForeignKey(x => x.DomainPermissionID)
                .IsRequired();

            builder.HasOne(x => x.ActionPermission)
                .WithMany(y => y.RoleRermissions)
                .HasForeignKey(x => x.ActionPermissionID)
                .IsRequired();
        }
    }
}
