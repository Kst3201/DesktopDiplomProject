using DesktopDiplomProject.ServerASP.Features.Assessment.Models;

namespace DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions
{
    public interface IDefuzzifyFunction
    {
        double Defuzzify(IScore score);
    }
}
