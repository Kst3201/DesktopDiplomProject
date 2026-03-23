using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.RAM
{
    public class RAMTypeConfiguration : BaseScoredConfiguration<RAMTypeEntity>
    {
        public override void Configure(EntityTypeBuilder<RAMTypeEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasIndex(x => x.Name)
                .IsUnique();

            base.Configure(builder);

            builder.HasMany(x => x.RAMs)
                .WithOne(y => y.RAMType)
                .HasForeignKey(y => y.RAMTypeID)
                .IsRequired();

            builder.HasMany(x => x.Motherboards)
                .WithOne(y => y.RAMType)
                .HasForeignKey(y => y.RAMTypeID)
                .IsRequired();

            builder.HasMany(x => x.CPUs)
                .WithOne(y => y.RAMType)
                .HasForeignKey(y => y.RAMTypeID)
                .IsRequired();
        }
    }
}
