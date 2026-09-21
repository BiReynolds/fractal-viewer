using System.Numerics;

namespace FractalViewer.Fractals
{
    public class FractalPoint
    {
        public Complex Location;
        public int EscapeIndex;
        public FractalPoint(Complex location, int escapeIndex)
        {
            Location = location;
            EscapeIndex = escapeIndex;
        }
    }
}