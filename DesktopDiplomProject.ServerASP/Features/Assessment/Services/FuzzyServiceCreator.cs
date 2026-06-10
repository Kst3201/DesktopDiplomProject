namespace DesktopDiplomProject.ServerASP.Features.Assessment.Services
{
    public enum FuzzyServiceType
    {
        Native
    }

    public class FuzzyServiceCreator
    {

        public FuzzyServiceCreator() { }

        public IFuzzyService<int> CreateInt(FuzzyServiceType type)
        {
            switch (type)
            {
                case FuzzyServiceType.Native:
                    {
                        return new FuzzyIntService();
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }

        public IFuzzyService<double> CreateDouble(FuzzyServiceType type)
        {
            switch (type)
            {
                case FuzzyServiceType.Native:
                    {
                        return new FuzzyDoubleService();
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }
    }
}
