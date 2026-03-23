using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.CPU
{
    public class CPUSocketConfiguration : IEntityTypeConfiguration<CPUSocketEntity>
    {
        public void Configure(EntityTypeBuilder<CPUSocketEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasMany(x => x.CPUs)
                .WithOne(y => y.Socket)
                .HasForeignKey(y => y.SocketID)
                .IsRequired();

            builder.HasMany(x => x.Motherboards)
                .WithOne(y => y.Socket)
                .HasForeignKey(y => y.SocketID)
                .IsRequired();
        }
    }
}
