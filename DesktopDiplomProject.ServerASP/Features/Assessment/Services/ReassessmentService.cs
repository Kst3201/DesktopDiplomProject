using DesktopDiplomProject.ServerASP.Features.Assessment.Models;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Services
{
    public class ReassessmentService
    {
        public static Score Commulate(params ScoreCoefficiented[] scores)
        {
            //double sum = GetSumCoefficients(scores.Select(item => item.Coefficient).ToList());
            //double scoreOne = 0;
            //double scoreTwo = 0;
            //double scoreThree = 0;
            //double scoreFour = 0;
            //double scoreFive = 0;
            //foreach (ScoreCoefficiented score in scores)
            //{
            //    scoreOne += score.ScoreOne;
            //    scoreTwo += score.ScoreTwo;
            //    scoreThree += score.ScoreThree;
            //    scoreFour += score.ScoreFour;
            //    scoreFive += score.ScoreFive;
            //}
            //scoreOne /= sum;
            //scoreTwo /= sum;
            //scoreThree /= sum;
            //scoreFour /= sum;
            //scoreFive /= sum;
            //return new Score(scoreOne, scoreTwo, scoreThree, scoreFour, scoreFive);

            if (scores == null || scores.Length == 0)
                return new Score(1, 0, 0, 0, 0); // Дефолтная монотонная

            double totalWeight = scores.Sum(s => s.Coefficient);

            // Взвешенное среднее для каждого уровня
            double c1 = scores.Sum(s => s.ScoreOne) / totalWeight;
            double c2 = scores.Sum(s => s.ScoreTwo) / totalWeight;
            double c3 = scores.Sum(s => s.ScoreThree) / totalWeight;
            double c4 = scores.Sum(s => s.ScoreFour) / totalWeight;
            double c5 = scores.Sum(s => s.ScoreFive) / totalWeight;

            // ВАЖНО: восстанавливаем монотонность (если нарушена)
            c1 = Math.Min(1.0, c1);
            c2 = Math.Min(c1, Math.Max(c2, c5)); // c2 не может быть больше c1
            c3 = Math.Min(c2, Math.Max(c3, c5));
            c4 = Math.Min(c3, Math.Max(c4, c5));
            c5 = Math.Min(c4, c5);

            return new Score(c1, c2, c3, c4, c5);
        }

        private static double GetSumCoefficients(List<double> coefficients)
        {
            return coefficients.Sum();
        }
    }
}
