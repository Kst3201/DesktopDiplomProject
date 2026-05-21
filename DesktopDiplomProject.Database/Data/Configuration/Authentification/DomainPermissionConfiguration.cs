using DesktopDiplomProject.Server.Models.Entities.Authentification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Authentification
{
    public class DomainPermissionConfiguration : IEntityTypeConfiguration<DomainPermissionEntity>
    {
        public void Configure(EntityTypeBuilder<DomainPermissionEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.Description);

            builder.HasMany(x => x.RolePermissions)
                .WithOne(y => y.DomainPermission)
                .HasForeignKey(y => y.DomainPermissionID)
                .IsRequired();
        }
    }
}
