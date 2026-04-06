using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.VideoCard
{
    public class VCPriceConfiguration : DoubleScoredConfiguration<VCPriceEntity>
    {
        public override void Configure(EntityTypeBuilder<VCPriceEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.VideoCards)
                .WithOne(y => y.Price)
                .HasForeignKey(y => y.PriceID)
                .IsRequired();
        }
    }
}
