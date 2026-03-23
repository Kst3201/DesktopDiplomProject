using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.RAM
{
    public class RAMFrequencyConfiguration : IntScoredConfiguration<RAMFrequencyEntity>
    {
        public override void Configure(EntityTypeBuilder<RAMFrequencyEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.RAMs)
                .WithOne(y => y.Frequency)
                .HasForeignKey(y => y.FrequencyID)
                .IsRequired();
        }
    }
}
