using DesktopDiplomProject.Database.Models.Entities.Authentification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Database.Data.Configuration.Authentification
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshTokenEntity>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Token)
                .IsRequired();

            builder.HasIndex(x => x.Token)
                .IsUnique();

            builder.HasOne(x => x.User)
                .WithMany(y => y.RefreshTokens)
                .HasForeignKey(x => x.UserID)
                .IsRequired();

            builder.Property(x => x.JWTID)
                .IsRequired();

            builder.Property(x => x.ExpiryDate)
                .IsRequired();

            builder.Property(x => x.IsRevoked)
                .HasDefaultValue(false);

            builder.Property(x => x.RevokedAt);

            builder.Property(x => x.RevokedByIP);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.CreatedByIP);

            builder.Property(x => x.UsedAt);

            builder.Property(x => x.UsedByIP);

            builder.HasOne(x => x.ReplacedByToken)
                .WithOne(x => x.ReplacedByTokenOf)
                .HasForeignKey<RefreshTokenEntity>(x => x.ReplacedByTokenID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.ReplacedByTokenID);

            builder.HasIndex(x => new { x.UserID, x.IsRevoked, x.ExpiryDate });
        }
    }
}
