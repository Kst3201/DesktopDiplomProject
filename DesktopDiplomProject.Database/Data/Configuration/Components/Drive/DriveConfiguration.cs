using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.Drive
{
    public class DriveConfiguration : IEntityTypeConfiguration<DriveEntity>
    {
        public void Configure(EntityTypeBuilder<DriveEntity> builder)
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

            builder.HasOne(x => x.SpeedDataTransfer)
                .WithMany(y => y.Drives)
                .HasForeignKey(x => x.SpeedDataTransferID)
                .IsRequired();

            builder.HasOne(x => x.ConnectorInterface)
                .WithMany(y => y.Drives)
                .HasForeignKey(x => x.ConnectorInterfaceID)
                .IsRequired();

            builder.HasOne(x => x.Capacity)
                .WithMany(y => y.Drives)
                .HasForeignKey(x => x.CapacityID)
                .IsRequired();

            builder.HasOne(x => x.Price)
                .WithMany(y => y.Drives)
                .HasForeignKey(x => x.PriceID)
                .IsRequired();

            builder.HasMany(x => x.PCs)
                .WithOne(y => y.Drive)
                .HasForeignKey(y => y.DriveID)
                .IsRequired();
        }
    }
}
