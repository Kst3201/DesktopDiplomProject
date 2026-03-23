using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.Motherboard
{
    public class MBPriceConfiguration : DoubleScoredConfiguration<MBPriceEntity>
    {
        public override void Configure(EntityTypeBuilder<MBPriceEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .IsRequired();

            base.Configure(builder);

            builder.HasMany(x => x.Motherboards)
                .WithOne(y => y.Price)
                .HasForeignKey(y => y.PriceID)
                .IsRequired();
        }
    }
}
