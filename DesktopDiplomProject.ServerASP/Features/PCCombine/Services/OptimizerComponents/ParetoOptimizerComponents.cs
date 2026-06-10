using DesktopDiplomProject.ServerASP.Features.Assessment.Comparers;
using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Services.ParetoOptimizers;
using DiplomDataLibrary.Assessments;
using System.Threading.Tasks;

namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Services.OptimizerComponents
{
    public class ParetoOptimizerComponents : IOptimizerComponents
    {
        private const double MINSTEP = 100;
        private const int MINCOUNTTOPS = 1;
        private double _priceStep;
        private int _countTopItemsPerRange;
        private FuzzyAssessments _assessment;
        private IScoreComparer _comparer;

        public double PriceStep 
        { 
            get => _priceStep;
            set
            {
                if (value < MINSTEP)
                {
                    _priceStep = MINSTEP;
                }
                else
                {
                    _priceStep = value;
                }
            }
        }

        public int CountTopItemsPerRange 
        { 
            get => _countTopItemsPerRange;
            set
            {
                if (value < MINCOUNTTOPS)
                {
                    _countTopItemsPerRange = MINCOUNTTOPS;
                }
                else
                {
                    _countTopItemsPerRange = value;
                }
            }
        }

        public FuzzyAssessments TargetAssessment 
        {
            get => _assessment;
            set => _assessment = value;
        }

        public ParetoOptimizerComponents()
        {
            PriceStep = MINSTEP;
            CountTopItemsPerRange = MINCOUNTTOPS;
            TargetAssessment = FuzzyAssessments.Excellent;
            _comparer = new NativeScoreComparer();
        }

        public IList<T> GetOptimizePerGroup<TKey, T>(
            IList<T> components, Func<T, TKey> getGroupKey, Func<T, double> getPrice, Func<T, IScore> getScore)
            where TKey : notnull
        {
            var groups = components.GroupBy(getGroupKey).ToDictionary(g => g.Key, g => g.ToList());
            var result = new Dictionary<TKey, List<T>>();
            foreach (var group in groups)
            {
                var paretoInGroup = GetParetoFrontInGroup(group.Value, getPrice, getScore);
                result[group.Key] = paretoInGroup;
            }
            var listResult = new List<T>();
            foreach (var value in result.Values)
            {
                listResult = listResult.Concat(value).ToList();
            }
            return listResult;
        }

        public async Task<IList<T>> GetOptimizePerGroupAsync<TKey, T>(
            IList<T> components, Func<T, TKey> getGroupKey, Func<T, double> getPrice, Func<T, IScore> getScore)
            where TKey : notnull
        {
            return await Task.Run(() => GetOptimizePerGroup(components, getGroupKey, getPrice, getScore));
        }

        private List<T> GetParetoFrontInGroup<T>(
            List<T> components,
            Func<T, double> getPrice,
            Func<T, IScore> getScore)
        {
            if (!components.Any()) return new List<T>();
            var priceGroups = components
                .GroupBy(c => (int)(getPrice(c) / PriceStep))
                .Select(item => new
                {
                    PriceRange = item.Key,
                    BestComponents = item
                        .OrderByDescending(c => getScore(c), _comparer)
                        .Take(CountTopItemsPerRange)
                        .ToList()
                }).OrderBy(item => item.PriceRange).ToList();
            var candidates = priceGroups.SelectMany(item => item.BestComponents).ToList();
            var sorted = candidates.OrderByDescending(item => getScore(item), _comparer)
                .ThenBy(item => getPrice(item)).ToList();
            var front = new List<T>();
            double minPrice = double.MaxValue;
            foreach (var item in sorted)
            {
                double price = getPrice(item);
                if (price < minPrice)
                {
                    front.Add(item);
                    minPrice = price;
                }
            }
            return front;
        }
    }
}
