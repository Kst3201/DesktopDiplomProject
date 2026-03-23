using DesktopDiplomProject.Server.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopDiplomProject.Server.Data.Configuration.Components
{
    [NotMapped]
    public class DoubleScoredConfiguration<T> : BaseScoredConfiguration<T> where T : DoubleValueScoredEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Value)
                .IsRequired();
        }
    }
}
