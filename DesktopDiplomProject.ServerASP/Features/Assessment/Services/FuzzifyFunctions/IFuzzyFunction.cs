namespace DesktopDiplomProject.ServerASP.Features.Assessment.Services.FuzzifyFunctions
{
    public interface IFuzzyFunction
    {
        double Fuzzify(int value);
        double FuzzifyMinShoulder(int value);
        double FuzzifyMaxShoulder(int value);
        double FuzzifyDouble(double value);
        double FuzzifyMinShoulderDouble(double value);
        double FuzzifyMaxShoulderDouble(double value);

    }

}
