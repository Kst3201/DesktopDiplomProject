using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.CPU
{
    public class CPUConfiguration : IEntityTypeConfiguration<CPUEntity>
    {
        public void Configure(EntityTypeBuilder<CPUEntity> builder)
        {
            builder.HasKey(model => model.ID);

            builder.Property(model => model.ID)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Manufacturer)
                .IsRequired();

            builder.Property(x => x.Model)
                .IsRequired();

            builder.HasOne(x => x.BaseFrequency)
                .WithMany(y => y.CPUs)
                .HasForeignKey(x => x.BaseFrequencyID)
                .IsRequired();

            builder.HasOne(x => x.CountCores)
                .WithMany(y => y.CPUs)
                .HasForeignKey(x => x.CountCoresID)
                .IsRequired();

            builder.HasOne(x => x.CountThreads)
                .WithMany(y => y.CPUs)
                .HasForeignKey(x => x.CountThreadsID)
                .IsRequired();

            builder.HasOne(x => x.RAMType)
                .WithMany(y => y.CPUs)
                .HasForeignKey(x => x.RAMTypeID)
                .IsRequired();

            builder.HasOne(x => x.Socket)
                .WithMany(y => y.CPUs)
                .HasForeignKey(x => x.SocketID)
                .IsRequired();

            builder.HasOne(x => x.Price)
                .WithMany(y => y.CPUs)
                .HasForeignKey(x => x.PriceID)
                .IsRequired();

            builder.HasMany(x => x.PCs)
                .WithOne(y => y.CPU)
                .HasForeignKey(y => y.CPUID)
                .IsRequired();
        }
    }
}
