using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.Motherboard
{
    public class MBRAMValueConfiguration : IntScoredConfiguration<MBRAMValueEntity>
    {
        public override void Configure(EntityTypeBuilder<MBRAMValueEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.Motherboards)
                .WithOne(y => y.MaxRAMValue)
                .HasForeignKey(y => y.MaxRAMValueID)
                .IsRequired();
        }
    }
}
