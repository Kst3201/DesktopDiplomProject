using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DiplomDataLibrary.Assessments;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Comparers
{
    public class DefuzzScoreComparer : IScoreComparer
    {
        private const double COEFF = 1.2;
        private readonly IDefuzzifyFunction _function;

        public DefuzzScoreComparer(IDefuzzifyFunction function)
        {
            _function = function;
        }

        public FuzzyAssessments? TargetAssessment { get; set; }

        public int Compare(IScore? x, IScore? y)
        {
            if (x == null && y == null) return 0;
            if (x == null && y != null) return -1;
            if (x != null && y == null) return 1;
            IScore xN = x ?? new Score();
            IScore yN = y ?? new Score();
            x = SetAccent(xN);
            y = SetAccent(yN);
            double xAssess = Math.Round(_function.Defuzzify(x ?? new Score()), 4);
            double yAssess = Math.Round(_function.Defuzzify(y ?? new Score()), 4);
            double sub = xAssess - yAssess;
            if (sub < 0) return 1;
            if (sub > 0) return -1;
            return 0;
        }

        private IScore SetAccent(IScore x)
        {
            if (TargetAssessment == null) return x;
            switch (TargetAssessment)
            {
                case FuzzyAssessments.Worst:
                    {
                        x.ScoreOne *= COEFF;
                        x.ScoreOne = x.ScoreOne > 1 ? 1 : x.ScoreOne;
                        break;
                    }
                case FuzzyAssessments.Bad:
                    {
                        x.ScoreTwo *= COEFF;
                        x.ScoreTwo = x.ScoreTwo > 1 ? 1 : x.ScoreTwo;
                        break;
                    }
                case FuzzyAssessments.Usual:
                    {
                        x.ScoreThree *= COEFF;
                        x.ScoreThree = x.ScoreThree > 1 ? 1 : x.ScoreThree;
                        break;
                    }
                case FuzzyAssessments.Good:
                    {
                        x.ScoreFour *= COEFF;
                        x.ScoreFour = x.ScoreFour > 1 ? 1 : x.ScoreFour;
                        break;
                    }
                case FuzzyAssessments.Excellent:
                    {
                        x.ScoreFive *= COEFF;
                        x.ScoreFive = x.ScoreFive > 1 ? 1 : x.ScoreFive;
                        break;
                    }
                default: return x;
            }
            return x;
        }
    }
}
