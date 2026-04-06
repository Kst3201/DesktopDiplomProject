using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.Motherboard
{
    public class MBCountM2SlotsConfiguration : IntScoredConfiguration<MBCountM2SlotsEntity>
    {
        public override void Configure(EntityTypeBuilder<MBCountM2SlotsEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.Motherboards)
                .WithOne(y => y.CountM2Slots)
                .HasForeignKey(y => y.CountM2SlotsID)
                .IsRequired();
        }
    }
}
