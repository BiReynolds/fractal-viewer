using System.Numerics;

namespace FractalViewer.Fractals
{
    public class FractalInfo
    {
        readonly Func<Complex, Complex, Complex> FractalFunction;
        readonly double EscapeRadius;
        public FractalInfo(Func<Complex, Complex, Complex> fractalFunction, double escapeRadius)
        {
            FractalFunction = fractalFunction;
            EscapeRadius = escapeRadius;
        }

        public int GetEscapeIndex(Complex startValue, Complex paramValue, int maxIterations)
        {
            Complex currValue = startValue;
            int currIterations = 0;
            while (currValue.Magnitude <= EscapeRadius && currIterations < maxIterations)
            {
                currValue = FractalFunction(currValue, paramValue);
                currIterations++;
            }

            if (currValue.Magnitude > EscapeRadius)
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