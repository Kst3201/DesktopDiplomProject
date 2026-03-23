using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.Drive
{
    public class DriveConnectionInterfaceConfiguration : IEntityTypeConfiguration<DriveConnectionInterfaceEntity>
    {
        public void Configure(EntityTypeBuilder<DriveConnectionInterfaceEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasMany(x => x.Drives)
                .WithOne(y => y.ConnectorInterface)
                .HasForeignKey(y => y.ConnectorInterfaceID)
                .IsRequired();
        }
    }
}
