using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.Motherboard
{
    public class MBRAMCountSlotsConfiguration : IntScoredConfiguration<MBRAMCountSlotsEntity>
    {
        public override void Configure(EntityTypeBuilder<MBRAMCountSlotsEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.Motherboards)
                .WithOne(y => y.RAMCountSlots)
                .HasForeignKey(y => y.RAMCountSlotsID)
                .IsRequired();
        }
    }
}
