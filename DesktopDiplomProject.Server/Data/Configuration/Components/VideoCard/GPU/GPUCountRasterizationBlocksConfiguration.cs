using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.VideoCard.GPU
{
    public class GPUCountRasterizationBlocksConfiguration : IntScoredConfiguration<GPUCountRasterizationBlocksEntity>
    {
        public override void Configure(EntityTypeBuilder<GPUCountRasterizationBlocksEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.GPUs)
                .WithOne(y => y.CountRasterizationBlocks)
                .HasForeignKey(y => y.CountRasterizationBlocksID)
                .IsRequired();
        }
    }
}
