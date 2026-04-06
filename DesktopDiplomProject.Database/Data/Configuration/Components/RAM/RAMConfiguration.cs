using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.RAM
{
    public class RAMConfiguration : IEntityTypeConfiguration<RAMEntity>
    {
        public void Configure(EntityTypeBuilder<RAMEntity> builder)
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

            builder.HasOne(x => x.CountModules)
                .WithMany(y => y.RAMs)
                .HasForeignKey(x => x.CountModulesID)
                .IsRequired();

            builder.HasOne(x => x.Frequency)
                .WithMany(y => y.RAMs)
                .HasForeignKey(x => x.FrequencyID)
                .IsRequired();

            builder.HasOne(x => x.Price)
                .WithMany(y => y.RAMs)
                .HasForeignKey(x => x.PriceID)
                .IsRequired();

            builder.HasOne(x => x.SingleModuleCapacity)
                .WithMany(y => y.RAMs)
                .HasForeignKey(x => x.SingleModuleCapacityID)
                .IsRequired();

            builder.HasOne(x => x.RAMType)
                .WithMany(y => y.RAMs)
                .HasForeignKey(x => x.RAMTypeID)
                .IsRequired();
        }
    }
}
