using DesktopDiplomProject.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Data.Configuration.Components
{
    [NotMapped]
    public class BaseScoredConfiguration<T> : IEntityTypeConfiguration<T> where T : ScoredEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(model => model.ScoreOne)
                .IsRequired();
            builder.Property(model => model.ScoreTwo)
                .IsRequired();
            builder.Property(model => model.ScoreThree)
                .IsRequired();
            builder.Property(model => model.ScoreFour)
                .IsRequired();
            builder.Property(model => model.ScoreFive)
                .IsRequired();
        }
    }
}
