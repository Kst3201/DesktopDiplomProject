using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.FuzzifyFunctions;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Services
{
    public class FuzzyIntService : IFuzzyService<int>
    {
        private const int COUNTFUNCTIONS = 5;
        private IFuzzyFunction[] _fuzzifyFucntions;
        private IDefuzzifyFunction _deffuzifyFunction;
        private int _max;
        private int _min;
        private bool _isInit;

        public FuzzyIntService()
        {
            _isInit = false;
            _max = 1;
            _min = 0;
            _fuzzifyFucntions = new TriangleFuzzyFunction[COUNTFUNCTIONS];
            _deffuzifyFunction = new WeightAverageOfPeaksDeffuzifyFunction();
            InitFuzzify(_max, _min);
        }

        public int Max => _max;

        public int Min => _min;

        public double Defazzify(Score score)
        {
            return _deffuzifyFunction.Defuzzify(score);
        }

        public ScoredEntity Fuzzify(int value, CriterialDirection direction = CriterialDirection.Ascending)
        {
            int assessValue = value;
            if (direction == CriterialDirection.Descending)
                assessValue = Max + Min - value;
            ScoredEntity score = new ScoredEntity()
            {
                ScoreOne = _fuzzifyFucntions[0].FuzzifyMinShoulder(assessValue),
                ScoreTwo = _fuzzifyFucntions[1].Fuzzify(assessValue),
                ScoreThree = _fuzzifyFucntions[2].Fuzzify(assessValue),
                ScoreFour = _fuzzifyFucntions[3].Fuzzify(assessValue),
                ScoreFive = _fuzzifyFucntions[4].FuzzifyMaxShoulder(assessValue)
            };
            return ToCommulateMonotoned(score);
        }

        public void SetMax(int value)
        {
            _max = value;
            int sub = _max - _min;
            if (sub <= 0) return;
            InitFuzzify(_max, _min);
        }

        public void SetMaxMin(int max, int min)
        {
            if (max == 0 && min == 0) return;
            if (max < min) throw new ArgumentOutOfRangeException(nameof(min));
            _max = max;
            _min = min;
            InitFuzzify(_max, _min);
        }

        public void SetMin(int value)
        {
            _min = value;
            int sub = _max - _min;
            if (sub <= 0) return;
            InitFuzzify(_max, _min);
        }

        private void InitFuzzify(int max, int min)
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
            double peak = min;
            for (int i = 1; i < COUNTFUNCTIONS - 1; i++)
            {
                peak += width;
                _fuzzifyFucntions[i] = new TriangleFuzzyFunction(peak, width);
            }
            _fuzzifyFucntions[COUNTFUNCTIONS - 1] = new TriangleFuzzyFunction(max, width);
        }

        public ScoredEntity ToCommulateMonotoned(ScoredEntity score)
        {
            var norm = Normalize(score);
            var commulate = ToCommulateForm(norm);
            return ToMonotoned(commulate);
        }

        private ScoredEntity ToMonotoned(ScoredEntity score)
        {
            List<double> values = new List<double>()
            {
                score.ScoreOne,
                score.ScoreTwo,
                score.ScoreThree,
                score.ScoreFour,
                score.ScoreFive
            };
            for (int i = 1; i < values.Count; i++)
            {
                if (values[i] > values[i - 1])
                    values[i] = values[i - 1];
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

        private ScoredEntity Normalize(ScoredEntity score)
        {
            double sum = score.ScoreOne + score.ScoreTwo + score.ScoreThree + score.ScoreFour + score.ScoreFive;
            var result = new ScoredEntity()
            {
                ScoreOne = score.ScoreOne,
                ScoreTwo = score.ScoreTwo,
                ScoreThree = score.ScoreThree,
                ScoreFour = score.ScoreFour,
                ScoreFive = score.ScoreFive
            };
            if (sum > 0)
            {
                result.ScoreOne /= sum;
                result.ScoreTwo /= sum;
                result.ScoreThree /= sum;
                result.ScoreFour /= sum;
                result.ScoreFive /= sum;
            }
            return result;
        }

        private ScoredEntity ToCommulateForm(ScoredEntity score)
        {
            var result = new ScoredEntity()
            {
                ScoreOne = score.ScoreOne,
                ScoreTwo = score.ScoreTwo,
                ScoreThree = score.ScoreThree,
                ScoreFour = score.ScoreFour,
                ScoreFive = score.ScoreFive
            };
            result.ScoreFour += result.ScoreFive;
            result.ScoreThree += result.ScoreFour;
            result.ScoreTwo += result.ScoreThree;
            result.ScoreOne += result.ScoreTwo;
            return result;
        }

    }

}
