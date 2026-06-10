using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DiplomDataLibrary.Assessments;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Comparers
{
    public class NativeScoreComparer : IScoreComparer
    {
        private const double EPSILON = 0.08;
        private IDefuzzifyFunction _function;

        public FuzzyAssessments? TargetAssessment 
        { 
            get;
            set;
        }
        
        public NativeScoreComparer() 
        {
            TargetAssessment = null;
            _function = new WeightAverageOfPeaksDeffuzifyFunction();
        }


        public int Compare(IScore? x, IScore? y)
        {
            if (x == null && y == null) return 0;
            if (x == null && y != null) return -1;
            if (x != null && y == null) return 1;
            IScore xN = x ?? new Score();
            IScore yN = y ?? new Score();
            List<double> xScores = GetScores(xN).ToList();
            List<double> yScores = GetScores(yN).ToList();
            int iTarget = GetTargetScoreIndex();
            var scoresToCheck = GetCheckOrder(iTarget);
            foreach (var score in scoresToCheck)
            {
                double diff = xScores[score] - yScores[score];
                double epsilon = score == iTarget ? EPSILON / 2 : EPSILON;
                if (Math.Abs(diff) > epsilon)
                {
                    if (diff < 0) return -1;
                    if (diff > 0) return 1;
                }
            }
            //double xS = _function.Defuzzify(xN);
            //double yS = _function.Defuzzify(yN);
            //double res = xS - yS;
            //if (res > 0) return 1;
            //if (res < 0) return - 1;
            return 0;
        }


        private int GetTargetScoreIndex()
        {
            if (TargetAssessment == null) return -1;
            switch (TargetAssessment)
            {
                case FuzzyAssessments.Worst: return 0;
                case FuzzyAssessments.Bad: return 1;
                case FuzzyAssessments.Usual: return 2;
                case FuzzyAssessments.Good: return 3;
                case FuzzyAssessments.Excellent: return 4;
                default: return -1;
            }
        }

        private IList<double> GetScores(IScore x)
        {
            return new List<double>()
            {
                Math.Round(x.ScoreOne, 3),
                Math.Round(x.ScoreTwo, 3),
                Math.Round(x.ScoreThree, 3),
                Math.Round(x.ScoreFour, 3),
                Math.Round(x.ScoreFive, 3)
            };
        }

        private IEnumerable<int> GetCheckOrder(int target)
        {
            if (target >= 0 && target <= 4)
            {
                // Сначала целевая оценка
                yield return target;

                // Затем вверх (лучшие оценки)
                for (int g = target + 1; g <= 4; g++)
                    yield return g;

                // Затем вниз (худшие оценки)
                for (int g = target - 1; g >= 0; g--)
                    yield return g;
            }
            else
            {
                // От худших к лучшим
                for (int g = 4; g >= 0; g--)
                    yield return g;
            }
        }
    }
}
