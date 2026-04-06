using DesktopDiplomProject.Server.Models.Entities.PersonalComputers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Data.Configuration.PersonalComputers
{
    public class PCConfiguration : IEntityTypeConfiguration<PCEntity>
    {
        public void Configure(EntityTypeBuilder<PCEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            builder.HasOne(x => x.CPU)
                .WithMany(y => y.PCs)
                .HasForeignKey(x => x.CPUID)
                .IsRequired();

            builder.HasOne(x => x.Motherboard)
                .WithMany(y => y.PCs)
                .HasForeignKey(x => x.MotherboardID)
                .IsRequired();

            builder.HasOne(x => x.Drive)
                .WithMany(y => y.PCs)
                .HasForeignKey(x => x.DriveID)
                .IsRequired();

            builder.HasOne(x => x.RAM)
                .WithMany(y => y.PCs)
                .HasForeignKey(x => x.RAMID)
                .IsRequired();

            builder.HasOne(x => x.VideoCard)
                .WithMany(y => y.PCs)
                .HasForeignKey(x => x.VideoCardID)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(y => y.PCs)
                .HasForeignKey(x => x.UserID)
                .IsRequired();

            builder.Property(x => x.DateCreate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();
        }
    }
}
