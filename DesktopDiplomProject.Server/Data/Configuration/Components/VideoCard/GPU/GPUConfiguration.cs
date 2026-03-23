using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.VideoCard.GPU
{
    public class GPUConfiguration : IEntityTypeConfiguration<GPUEntity>
    {
        public void Configure(EntityTypeBuilder<GPUEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(model => model.ID)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Manufacturer)
                .IsRequired();

            builder.Property(x => x.Model)
                .IsRequired();

            builder.HasOne(x => x.BaseFrequency)
                .WithMany(y => y.GPUs)
                .HasForeignKey(x => x.BaseFrequencyID)
                .IsRequired();

            builder.HasOne(x => x.CountUniversalProcessors)
                .WithMany(y => y.GPUs)
                .HasForeignKey(x => x.CountUniversalProcessorsID)
                .IsRequired();

            builder.HasOne(x => x.CountTexturerBlocks)
                .WithMany(y => y.GPUs)
                .HasForeignKey(x => x.CountTexturerBlocksID)
                .IsRequired();

            builder.HasOne(x => x.CountRasterizationBlocks)
                .WithMany(y => y.GPUs)
                .HasForeignKey(x => x.CountRasterizationBlocksID)
                .IsRequired();

            builder.HasOne(x => x.CountRTCores)
                .WithMany(y => y.GPUs)
                .HasForeignKey(x => x.CountRTCoresID)
                .IsRequired();

            builder.HasOne(x => x.CountTensorCores)
                .WithMany(y => y.GPUs)
                .HasForeignKey(x => x.CountTensorCoresID)
                .IsRequired();

            builder.HasMany(x => x.VideoCards)
                .WithOne(y => y.GPU)
                .HasForeignKey(y => y.GPUID)
                .IsRequired(); ;
        }
    }
}
