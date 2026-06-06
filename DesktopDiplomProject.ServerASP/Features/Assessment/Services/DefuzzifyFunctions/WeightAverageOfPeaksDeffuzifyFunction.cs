using DesktopDiplomProject.ServerASP.Features.Assessment.Models;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions
{
    public class WeightAverageOfPeaksDeffuzifyFunction : IDefuzzifyFunction
    {
        public double Defuzzify(IScore score)
        {
            double result = 0;
            double divider = 0;
            result += 1 * score.ScoreOne;
            result += 2 * score.ScoreTwo;
            result += 3 * score.ScoreThree;
            result += 4 * score.ScoreFour;
            result += 5 * score.ScoreFive;
            divider += score.ScoreOne;
            divider += score.ScoreTwo;
            divider += score.ScoreThree;
            divider += score.ScoreFour;
            divider += score.ScoreFive;
            return Math.Round((double)result / divider, 3);
        }
    }
}
