using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DiplomDataLibrary.Assessments;

namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Services.ParetoOptimizers
{
    public interface IOptimizerComponents
    {
        double PriceStep { get; set; }
        int CountTopItemsPerRange { get; set; }
        FuzzyAssessments TargetAssessment { get; set; }

        IList<T> GetOptimizePerGroup<TKey, T>(
            IList<T> components,
            Func<T, TKey> getGroupKey,
            Func<T, double> getPrice,
            Func<T, IScore> getScore)
            where TKey : notnull;

        Task<IList<T>> GetOptimizePerGroupAsync<TKey, T>(
            IList<T> components,
            Func<T, TKey> getGroupKey,
            Func<T, double> getPrice,
            Func<T, IScore> getScore)
            where TKey : notnull;
    }
}
