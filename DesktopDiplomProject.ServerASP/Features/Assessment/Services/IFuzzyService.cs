using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.ServerASP.Features.Assessment.Models;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Services
{

    public interface IFuzzyService<T>
    {
        T Max { get; }
        T Min { get; }

        ScoredEntity Fuzzify(T value, CriterialDirection direction = CriterialDirection.Ascending);
        double Defazzify(Score score);

        void SetMax(T value);
        void SetMin(T value);
        void SetMaxMin(T max, T min);

        ScoredEntity ToMonotoned(ScoredEntity score);
    }

}
