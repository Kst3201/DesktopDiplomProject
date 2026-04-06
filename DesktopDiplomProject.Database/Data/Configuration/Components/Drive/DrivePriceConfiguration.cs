using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.Drive
{
    public class DrivePriceConfiguration : DoubleScoredConfiguration<DrivePriceEntity>
    {
        public override void Configure(EntityTypeBuilder<DrivePriceEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.Drives)
                .WithOne(y => y.Price)
                .HasForeignKey(y => y.PriceID)
                .IsRequired();
        }
    }
}
