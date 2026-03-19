using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Models.Entities
{
    [NotMapped]
    public class IntValueScoredEntity : ScoredEntity
    {
        [Required]
        public int Value { get; set; } = 0;
    }
}
