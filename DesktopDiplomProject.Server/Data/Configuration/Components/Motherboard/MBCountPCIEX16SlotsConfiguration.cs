using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.Motherboard
{
    public class MBCountPCIEX16SlotsConfiguration : IntScoredConfiguration<MBCountPCIEX16SlotsEntity>
    {
        public override void Configure(EntityTypeBuilder<MBCountPCIEX16SlotsEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.Motherboards)
                .WithOne(y => y.CountPCIEX16Slots)
                .HasForeignKey(y => y.CountPCIEX16SlotsID)
                .IsRequired();
        }
    }
}
