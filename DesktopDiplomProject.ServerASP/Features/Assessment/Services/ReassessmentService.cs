using DesktopDiplomProject.ServerASP.Features.Assessment.Models;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Services
{
    public class ReassessmentService
    {
        public static Score Commulate(params ScoreCoefficiented[] scores)
        {
            double sum = GetSumCoefficients(scores.Select(item => item.Coefficient).ToList());
            double scoreOne = 0;
            double scoreTwo = 0;
            double scoreThree = 0;
            double scoreFour = 0;
            double scoreFive = 0;
            foreach (ScoreCoefficiented score in scores)
            {
                scoreOne += score.ScoreOne;
                scoreTwo += score.ScoreTwo;
                scoreThree += score.ScoreThree;
                scoreFour += score.ScoreFour;
                scoreFive += score.ScoreFive;
            }
            scoreOne /= sum;
            scoreTwo /= sum;
            scoreThree /= sum;
            scoreFour /= sum;
            scoreFive /= sum;
            return new Score(scoreOne, scoreTwo, scoreThree, scoreFour, scoreFive);
        }

        private static double GetSumCoefficients(List<double> coefficients)
        {
            return coefficients.Sum();
        }
    }
}
