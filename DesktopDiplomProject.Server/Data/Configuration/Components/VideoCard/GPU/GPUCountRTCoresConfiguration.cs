using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.VideoCard.GPU
{
    public class GPUCountRTCoresConfiguration : IntScoredConfiguration<GPUCountRTCoresEntity>
    {
        public override void Configure(EntityTypeBuilder<GPUCountRTCoresEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.GPUs)
                .WithOne(y => y.CountRTCores)
                .HasForeignKey(y => y.CountRTCoresID)
                .IsRequired();
        }
    }
}
