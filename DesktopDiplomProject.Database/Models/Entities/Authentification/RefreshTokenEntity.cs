using DesktopDiplomProject.Server.Models.Entities.Authentification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Database.Models.Entities.Authentification
{
    [Table("RefreshTokens")]
    public class RefreshTokenEntity
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Token { get; set; } = string.Empty;

        [Required]
        public int UserID { get; set; }
        public UserEntity User { get; set; } = null!;

        [Required]
        public string JWTID { get; set; } = string.Empty;

        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; } = false;
        public DateTime? RevokedAt { get; set; }
        public string? RevokedByIP { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedByIP { get; set; }
        public DateTime? UsedAt { get; set; }
        public string? UsedByIP { get; set; }

        public int? ReplacedByTokenID { get; set; }
        public RefreshTokenEntity? ReplacedByToken { get; set; }
        public RefreshTokenEntity? ReplacedByTokenOf { get; set; }
    }
}
