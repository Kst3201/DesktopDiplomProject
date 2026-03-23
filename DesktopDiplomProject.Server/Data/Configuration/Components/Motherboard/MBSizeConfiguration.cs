using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.Motherboard
{
    public class MBSizeConfiguration : IEntityTypeConfiguration<MBSizeEntity>
    {
        public void Configure(EntityTypeBuilder<MBSizeEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasMany(x => x.Motherboards)
                .WithOne(y => y.Size)
                .HasForeignKey(y => y.SizeID)
                .IsRequired();
        }
    }
}
