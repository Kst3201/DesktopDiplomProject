using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.CPU
{
    public class CPUPriceConfiguration : DoubleScoredConfiguration<CPUPriceEntity>
    {
        public override void Configure(EntityTypeBuilder<CPUPriceEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.CPUs)
                .WithOne(y => y.Price)
                .HasForeignKey(y => y.PriceID)
                .IsRequired();
        }
    }
}
