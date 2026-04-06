using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.VideoCard.GPU
{
    public class GPUCountUniversalProcessorsConfiguration : IntScoredConfiguration<GPUCountUniversalProcessorsEntity>
    {
        public override void Configure(EntityTypeBuilder<GPUCountUniversalProcessorsEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.GPUs)
                .WithOne(y => y.CountUniversalProcessors)
                .HasForeignKey(y => y.CountUniversalProcessorsID)
                .IsRequired();
        }
    }
}
