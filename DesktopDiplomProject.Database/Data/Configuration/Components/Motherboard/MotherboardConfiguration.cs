using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.Motherboard
{
    public class MotherboardConfiguration : IEntityTypeConfiguration<MotherboardEntity>
    {
        public void Configure(EntityTypeBuilder<MotherboardEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Manufacturer)
                .IsRequired();

            builder.Property(x => x.Model)
                .IsRequired();

            builder.HasOne(x => x.CountM2Slots)
                .WithMany(y => y.Motherboards)
                .HasForeignKey(x => x.CountM2SlotsID)
                .IsRequired();

            builder.HasOne(x => x.CountSATASlots)
                .WithMany(y => y.Motherboards)
                .HasForeignKey(x => x.CountSATASlotsID)
                .IsRequired();

            builder.HasOne(x => x.PCIEInterface)
                .WithMany(y => y.Motherboards)
                .HasForeignKey(x => x.PCIEInterfaceID)
                .IsRequired();

            builder.HasOne(x => x.CountPCIEX16Slots)
                .WithMany(y => y.Motherboards)
                .HasForeignKey(x => x.CountPCIEX16SlotsID)
                .IsRequired();

            builder.HasOne(x => x.RAMType)
                .WithMany(y => y.Motherboards)
                .HasForeignKey(x => x.RAMTypeID)
                .IsRequired();

            builder.HasOne(x => x.MaxRAMFrequency)
                .WithMany(y => y.Motherboards)
                .HasForeignKey(x => x.MaxRAMFrequencyID)
                .IsRequired();

            builder.HasOne(x => x.RAMCountSlots)
                .WithMany(y => y.Motherboards)
                .HasForeignKey(x => x.RAMCountSlotsID)
                .IsRequired();

            builder.HasOne(x => x.MaxRAMValue)
                .WithMany(y => y.Motherboards)
                .HasForeignKey(x => x.MaxRAMValueID)
                .IsRequired();

            builder.HasOne(x => x.Socket)
                .WithMany(y => y.Motherboards)
                .HasForeignKey(x => x.SocketID)
                .IsRequired();

            builder.HasOne(x => x.Size)
                .WithMany(y => y.Motherboards)
                .HasForeignKey(x => x.SizeID)
                .IsRequired();

            builder.HasOne(x => x.Price)
                .WithMany(y => y.Motherboards)
                .HasForeignKey(x => x.PriceID)
                .IsRequired();

            builder.HasMany(x => x.PCs)
                .WithOne(y => y.Motherboard)
                .HasForeignKey(y => y.MotherboardID)
                .IsRequired();
        }
    }
}
