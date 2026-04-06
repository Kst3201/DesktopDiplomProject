using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.Motherboard
{
    public class MBCountSATASlotsConfiguration : IntScoredConfiguration<MBCountSATASlotsEntity>
    {
        public override void Configure(EntityTypeBuilder<MBCountSATASlotsEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.Motherboards)
                .WithOne(y => y.CountSATASlots)
                .HasForeignKey(y => y.CountSATASlotsID)
                .IsRequired();
        }
    }
}
