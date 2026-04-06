using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.VideoCard
{
    public class PCIEInterfaceConfiguration : IEntityTypeConfiguration<PCIEInterfaceEntity>
    {
        public void Configure(EntityTypeBuilder<PCIEInterfaceEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(model => model.ID)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasMany(x => x.Motherboards)
                .WithOne(y => y.PCIEInterface)
                .HasForeignKey(y => y.PCIEInterfaceID)
                .IsRequired();

            builder.HasMany(x => x.VideoCards)
                .WithOne(y => y.PCIEInterface)
                .HasForeignKey(y => y.PCIEInterfaceID)
                .IsRequired();
        }
    }
}
