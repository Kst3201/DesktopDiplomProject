using DesktopDiplomProject.Server.Models.Entities;
using System.Text.Json.Serialization;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Models
{
    public class Score : IScore
    {
        public double ScoreOne { get; set; }
        public double ScoreTwo { get; set; }
        public double ScoreThree { get; set; }
        public double ScoreFour { get; set; }
        public double ScoreFive { get; set; }

        public Score()
        {
            ScoreOne = 0;
            ScoreTwo = 0;
            ScoreThree = 0;
            ScoreFour = 0;
            ScoreFive = 0;
        }

        [JsonConstructor]
        public Score(double scoreOne, double scoreTwo, double scoreThree, double scoreFour, double scoreFive)
        {
            ScoreOne = scoreOne;
            ScoreTwo = scoreTwo;
            ScoreThree = scoreThree;
            ScoreFour = scoreFour;
            ScoreFive = scoreFive;
        }

        public ScoredEntity GetEntity()
        {
            return new ScoredEntity()
            {
                ScoreOne = this.ScoreOne,
                ScoreTwo = this.ScoreTwo,
                ScoreThree = this.ScoreThree,
                ScoreFour = this.ScoreFour,
                ScoreFive = this.ScoreFive
            };
        }
    }
}
