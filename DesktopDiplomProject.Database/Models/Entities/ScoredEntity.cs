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
    public class ScoredEntity
    {
        [Required]
        public double ScoreOne { get; set; } = 0;
        [Required]
        public double ScoreTwo { get; set; } = 0;
        [Required]
        public double ScoreThree { get; set; } = 0;
        [Required]
        public double ScoreFour { get; set; } = 0;
        [Required]
        public double ScoreFive { get; set; } = 0;

        public void SetScore(ScoredEntity score)
        {
            ScoreOne = score.ScoreOne;
            ScoreTwo = score.ScoreTwo;
            ScoreThree = score.ScoreThree;
            ScoreFour = score.ScoreFour;
            ScoreFive = score.ScoreFive;
        }
    }
}
