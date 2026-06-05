using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.FuzzifyFunctions;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Services
{
    public class FuzzyDoubleService : IFuzzyService<double>
    {
        private const int COUNTFUNCTIONS = 5;
        private IFuzzyFunction[] _fuzzifyFucntions;
        private IDefuzzifyFunction _deffuzifyFunction;
        private double _max;
        private double _min;
        private bool _isInit;

        public FuzzyDoubleService()
        {
            _isInit = false;
            _max = 1;
            _min = 0;
            _fuzzifyFucntions = new TriangleFuzzyFunction[COUNTFUNCTIONS];
            _deffuzifyFunction = new WeightAverageOfPeaksDeffuzifyFunction();
            InitFuzzify(_max, _min);
        }

        public double Max => _max;

        public double Min => _min;

        public double Defazzify(Score score)
        {
            return _deffuzifyFunction.Defuzzify(score);
        }

        public ScoredEntity Fuzzify(double value, CriterialDirection direction = CriterialDirection.Ascending)
        {
            double assessValue = value;
            if (direction == CriterialDirection.Descending)
            {
                assessValue = Max + Min - value;
            }
            ScoredEntity score = new ScoredEntity()
            {
                ScoreOne = _fuzzifyFucntions[0].FuzzifyMinShoulderDouble(assessValue),
                ScoreTwo = _fuzzifyFucntions[1].FuzzifyDouble(assessValue),
                ScoreThree = _fuzzifyFucntions[2].FuzzifyDouble(assessValue),
                ScoreFour = _fuzzifyFucntions[3].FuzzifyDouble(assessValue),
                ScoreFive = _fuzzifyFucntions[4].FuzzifyMaxShoulderDouble(assessValue)
            };
            return ToMonotoned(score);
        }

        public void SetMax(double value)
        {
            _max = value;
            double sub = _max - _min;
            if (sub <= 0) return;
            InitFuzzify(_max, _min);
        }

        public void SetMaxMin(double max, double min)
        {
            if (max <= min) throw new ArgumentOutOfRangeException(nameof(min));
            _max = max;
            _min = min;
            InitFuzzify(_max, _min);
        }

        public void SetMin(double value)
        {
            _min = value;
            double sub = _max - _min;
            if (sub <= 0) return;
            InitFuzzify(_max, _min);
        }

        public ScoredEntity ToMonotoned(ScoredEntity score)
        {
            List<double> values = new List<double>()
            {
                score.ScoreOne,
                score.ScoreTwo,
                score.ScoreThree,
                score.ScoreFour,
                score.ScoreFive
            };
            double maxSoFar = 1;
            for (int i = 0; i < values.Count; i++)
            {
                maxSoFar = Math.Min(maxSoFar, values[i]);
                values[i] = maxSoFar;
            }
            return new ScoredEntity()
            {
                ScoreOne = values[0],
                ScoreTwo = values[1],
                ScoreThree = values[2],
                ScoreFour = values[3],
                ScoreFive = values[4]
            };
        }

        private void InitFuzzify(double max, double min)
        {
            double width = 0;
            if (max == min)
            {
                width = 1;
            }
            else
            {
                width = (max - min) / (COUNTFUNCTIONS - 1);
            }
            _fuzzifyFucntions[0] = new TriangleFuzzyFunction(min, width);
            for (int i = 1; i < COUNTFUNCTIONS - 1; i++)
            {
                _fuzzifyFucntions[i] = new TriangleFuzzyFunction(min + i * width, width);
            }
            _fuzzifyFucntions[COUNTFUNCTIONS - 1] = new TriangleFuzzyFunction(max, width);
        }
    }

}
