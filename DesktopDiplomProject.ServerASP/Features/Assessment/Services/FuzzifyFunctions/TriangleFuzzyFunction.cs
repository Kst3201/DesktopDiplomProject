namespace DesktopDiplomProject.ServerASP.Features.Assessment.Services.FuzzifyFunctions
{
    public class TriangleFuzzyFunction : IFuzzyFunction
    {
        private const double WIDTHCOEFFICIENT = 1.5;
        private double _peak;
        private double _leftEdge;
        private double _rightEdge;

        public TriangleFuzzyFunction(double peak, double width)
        {
            _peak = peak;
            _leftEdge = _peak - WIDTHCOEFFICIENT * width;
            _leftEdge = _leftEdge < 0 ? 0 : _leftEdge;
            _rightEdge = _peak + WIDTHCOEFFICIENT * width;
        }

        public double Fuzzify(int value)
        {
            if (value <= _leftEdge || value >= _rightEdge) return 0;
            double denominator = _peak - _leftEdge;
            if (denominator == 0) return 0;
            if (value <= _peak) return Math.Round((double)((value - _leftEdge) / (_peak - _leftEdge)), 3);
            denominator = _rightEdge - _peak;
            if (denominator == 0) return 0;
            return Math.Round((double)((_rightEdge - value) / (_rightEdge - _peak)), 3);
        }

        public double FuzzifyMaxShoulder(int value)
        {
            if (value >= _peak) return 1;
            if (value <= _leftEdge) return 0;
            if (value <= _peak) return Math.Round((double)((value - _leftEdge) / (_peak - _leftEdge)), 3);
            return Math.Round((double)((_rightEdge - value) / (_rightEdge - _peak)), 3);
        }

        public double FuzzifyMinShoulder(int value)
        {
            if (value <= _peak) return 1;
            if (value >= _rightEdge) return 0;
            if (value <= _peak) return Math.Round((double)((value - _leftEdge) / (_peak - _leftEdge)), 3);
            return Math.Round((double)((_rightEdge - value) / (_rightEdge - _peak)), 3);
        }

        public double FuzzifyDouble(double value)
        {
            if (value <= _leftEdge || value >= _rightEdge) return 0;
            if (value <= _peak) return Math.Round((double)((value - _leftEdge) / (_peak - _leftEdge)), 3);
            return Math.Round((double)((_rightEdge - value) / (_rightEdge - _peak)), 3);
        }

        public double FuzzifyMaxShoulderDouble(double value)
        {
            if (value >= _peak) return 1;
            if (value <= _leftEdge) return 0;
            if (value <= _peak) return Math.Round((double)((value - _leftEdge) / (_peak - _leftEdge)), 3);
            return Math.Round((double)((_rightEdge - value) / (_rightEdge - _peak)), 3);
        }

        public double FuzzifyMinShoulderDouble(double value)
        {
            if (value <= _peak) return 1;
            if (value >= _rightEdge) return 0;
            if (value <= _peak) return Math.Round((double)((value - _leftEdge) / (_peak - _leftEdge)), 3);
            return Math.Round((double)((_rightEdge - value) / (_rightEdge - _peak)), 3);
        }
    }

}
