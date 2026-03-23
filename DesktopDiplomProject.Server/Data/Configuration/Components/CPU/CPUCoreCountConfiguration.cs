using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.CPU
{
    public class CPUCoreCountConfiguration : BaseScoredConfiguration<CPUCoreCountEntity>
    {
        public override void Configure(EntityTypeBuilder<CPUCoreCountEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.CPUs)
                .WithOne(y => y.CountCores)
                .HasForeignKey(y => y.CountCoresID)
                .IsRequired();
        }
    }
}
