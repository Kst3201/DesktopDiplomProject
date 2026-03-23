using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesktopDiplomProject.Server.Data.Configuration.Components.RAM
{
    public class RAMCountModulesConfiguration : IntScoredConfiguration<RAMCountModulesEntity>
    {
        public override void Configure(EntityTypeBuilder<RAMCountModulesEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            base.Configure(builder);

            builder.HasMany(x => x.RAMs)
                .WithOne(y => y.CountModules)
                .HasForeignKey(y => y.CountModulesID)
                .IsRequired();
        }
    }
}
