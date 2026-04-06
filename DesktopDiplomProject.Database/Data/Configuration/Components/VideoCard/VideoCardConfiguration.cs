using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.VideoCard
{
    internal class VideoCardConfiguration : IEntityTypeConfiguration<VideoCardEntity>
    {
        public void Configure(EntityTypeBuilder<VideoCardEntity> builder)
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

            builder.HasOne(x => x.GPU)
                .WithMany(y => y.VideoCards)
                .HasForeignKey(x => x.GPUID)
                .IsRequired();

            builder.HasOne(x => x.PCIEInterface)
                .WithMany(y => y.VideoCards)
                .HasForeignKey(x => x.PCIEInterfaceID)
                .IsRequired();

            builder.Property(x => x.CountPCIELines)
                .IsRequired();

            builder.Property(x => x.RecommendedBlockPower)
                .IsRequired();

            builder.Property(x => x.CountPinsAdditionalPower)
                .IsRequired();

            builder.HasOne(x => x.CapacityVideoMemory)
                .WithMany(y => y.VideoCards)
                .HasForeignKey(x => x.CapacityVideoMemoryID)
                .IsRequired();

            builder.HasOne(x => x.MaxThroughputCapacity)
                .WithMany(y => y.VideoCards)
                .HasForeignKey(x => x.MaxThroughputCapacityID)
                .IsRequired();

            builder.HasOne(x => x.MemoryFrequency)
                .WithMany(y => y.VideoCards)
                .HasForeignKey(x => x.MemoryFrequencyID)
                .IsRequired();

            builder.HasOne(x => x.CountMonitors)
                .WithMany(y => y.VideoCards)
                .HasForeignKey(x => x.CountMonitorsID)
                .IsRequired();

            builder.HasOne(x => x.Price)
                .WithMany(y => y.VideoCards)
                .HasForeignKey(x => x.PriceID)
                .IsRequired();

            builder.HasMany(x => x.PCs)
                .WithOne(y => y.VideoCard)
                .HasForeignKey(y => y.VideoCardID)
                .IsRequired();
        }
    }
}
