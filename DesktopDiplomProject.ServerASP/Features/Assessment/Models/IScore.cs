using DesktopDiplomProject.Server.Models.Entities;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Models
{
    public interface IScore
    {
        double ScoreOne { get; set; }
        double ScoreTwo { get; set; }
        double ScoreThree { get; set; }
        double ScoreFour { get; set; }
        double ScoreFive { get; set; }

        ScoredEntity GetEntity();
    }
}
