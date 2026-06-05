using DesktopDiplomProject.Server.Models.Entities;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Models
{
    public class ScoreCoefficiented : IScore
    {
        private double _coefficient;
        private IScore _score;

        public double Coefficient
        {
            get => _coefficient;
            set => _coefficient = value;
        }

        public double ScoreOne 
        { 
            get => _score.ScoreOne * _coefficient;
            set => _score.ScoreOne = value / _coefficient;
        }
        public double ScoreTwo 
        { 
            get => _score.ScoreTwo * _coefficient;
            set => _score.ScoreTwo = value / _coefficient; 
        }
        public double ScoreThree 
        {
            get => _score.ScoreThree * _coefficient;
            set => _score.ScoreThree = value / _coefficient; 
        }
        public double ScoreFour
        { 
            get => _score.ScoreFour * _coefficient; 
            set => _score.ScoreFour = value / _coefficient;
        }
        public double ScoreFive 
        {
            get => _score.ScoreFive * _coefficient; 
            set => _score.ScoreFive = value / _coefficient; 
        }

        public ScoreCoefficiented(IScore score, double coefficient)
        {
            _score = score;
            _coefficient = coefficient;
        }

        public ScoredEntity GetEntity()
        {
            return new ScoredEntity()
            {
                ScoreOne = ScoreOne,
                ScoreTwo = ScoreTwo,
                ScoreThree = ScoreThree,
                ScoreFour = ScoreFour,
                ScoreFive = ScoreFive
            };
        }
    }
}
