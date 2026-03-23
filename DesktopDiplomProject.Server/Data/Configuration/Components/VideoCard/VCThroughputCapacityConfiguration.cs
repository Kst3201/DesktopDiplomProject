using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.VideoCard
{
    public class VCThroughputCapacityConfiguration : IntScoredConfiguration<VCThroughputCapacityEntity>
    {
        public override void Configure(EntityTypeBuilder<VCThroughputCapacityEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.VideoCards)
                .WithOne(y => y.MaxThroughputCapacity)
                .HasForeignKey(y => y.MaxThroughputCapacityID)
                .IsRequired();
        }
    }
}
