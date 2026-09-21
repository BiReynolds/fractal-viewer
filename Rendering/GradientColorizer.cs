using Raylib_cs;

namespace FractalViewer.Rendering
{
    public class GradientColorizer : IFractalColorizer
    {
        int MaxIterations;
        double Power;
        Color OnColorLimit, OffColorLimit;
        public GradientColorizer(Color onColorLimit, Color offColorLimit, int maxIterations, double power = 1)
        {
            MaxIterations = maxIterations;
            OnColorLimit = onColorLimit;
            OffColorLimit = offColorLimit;
            Power = power;
            Console.WriteLine(Power);
        }

        public Color GetColorFromEscapeIndex(int escapeIndex)
        {
            if (escapeIndex == -1)
            {
                return OnColorLimit;
            }
            double gradientProgress = Math.Pow((double)escapeIndex / (double)MaxIterations, Power);
            double newRed = (1 - gradientProgress) * OffColorLimit.R + gradientProgress * OnColorLimit.R;
            double newGreen = (1 - gradientProgress) * OffColorLimit.G + gradientProgress * OnColorLimit.G;
            double newBlue = (1 - gradientProgress) * OffColorLimit.B + gradientProgress * OnColorLimit.B;
            return new Color((int)newRed, (int)newGreen, (int)newBlue);
        }
    }
}