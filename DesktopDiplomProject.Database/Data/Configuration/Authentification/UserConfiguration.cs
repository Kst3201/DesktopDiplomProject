using DesktopDiplomProject.Server.Models.Entities.Authentification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Data.Configuration.Authentification
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Login)
                .IsRequired();

            builder.HasIndex(x => x.Login)
                .IsUnique();

            builder.Property(x => x.Password)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.HasOne(x => x.Role)
                .WithMany(y => y.Users)
                .HasForeignKey(x => x.RoleID)
                .IsRequired();

            builder.HasMany(x => x.PCs)
                .WithOne(y => y.User)
                .HasForeignKey(y => y.UserID)
                .IsRequired();

            builder.HasMany(x => x.RefreshTokens)
                .WithOne(y => y.User)
                .HasForeignKey(y => y.UserID)
                .IsRequired();
        }
    }
}
