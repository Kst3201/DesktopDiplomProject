using DesktopDiplomProject.ServerASP.Features.Assessment.Models;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions
{
    public class WeightAverageOfPeaksDeffuzifyFunction : IDefuzzifyFunction
    {
        public double Defuzzify(IScore score)
        {
            var result = score.ScoreOne + score.ScoreTwo + score.ScoreThree + score.ScoreFour + score.ScoreFive;
            return Math.Round(result, 3);
        }
    }
}
