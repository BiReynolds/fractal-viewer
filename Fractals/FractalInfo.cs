using System.Numerics;

namespace FractalViewer.Fractals
{
    public class FractalInfo
    {
        readonly Func<Complex, Complex, Complex> FractalFunction;
        readonly Func<Complex, double> EscapeRadiusSelector;
        public FractalInfo(Func<Complex, Complex, Complex> fractalFunction, Func<Complex, double> escapeRadiusSelector)
        {
            FractalFunction = fractalFunction;
            EscapeRadiusSelector = escapeRadiusSelector;
        }

        public int GetEscapeIndex(Complex startValue, Complex paramValue, int maxIterations)
        {
            double escapeRadius = EscapeRadiusSelector(paramValue);
            Complex currValue = startValue;
            int currIterations = 0;
            while (currValue.Magnitude <= escapeRadius && currIterations < maxIterations)
            {
                currValue = FractalFunction(currValue, paramValue);
                currIterations++;
            }

            if (currValue.Magnitude > escapeRadius)
            {
                return currIterations;
            }
            else
            {
                return -1;
            }
        }
    }
}