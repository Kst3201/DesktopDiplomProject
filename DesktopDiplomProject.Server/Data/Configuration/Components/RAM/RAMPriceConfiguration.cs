using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.RAM
{
    public class RAMPriceConfiguration : DoubleScoredConfiguration<RAMPriceEntity>
    {
        public override void Configure(EntityTypeBuilder<RAMPriceEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.RAMs)
                .WithOne(y => y.Price)
                .HasForeignKey(y => y.PriceID)
                .IsRequired();
        }
    }
}
