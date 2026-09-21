using System.Numerics;

namespace FractalViewer.Fractals
{
    public class FractalImageParameters
    {
        public Complex TopLeftLocation, BottomRightLocation;
        public int NumRows, NumCols;
        public int MaxIterations;
        public double Delta;
        public FractalImageParameters(Complex topLeftLoc, Complex bottomRightLoc, int numRows, int maxIterations)
        {
            TopLeftLocation = topLeftLoc;
            BottomRightLocation = bottomRightLoc;
            NumRows = numRows;
            MaxIterations = maxIterations;
            Delta = GetDelta(TopLeftLocation, BottomRightLocation, NumRows);
            NumCols = GetNumCols(TopLeftLocation, BottomRightLocation, Delta);
        }

        private static double GetDelta(Complex topLeftLoc, Complex bottomRightLoc, int numRows)
        {
            double realRange = bottomRightLoc.Real - topLeftLoc.Real;
            return realRange / (numRows - 1);
        }

        private static int GetNumCols(Complex topLeftLoc, Complex bottomRightLoc, double delta)
        {
            double imagRange = topLeftLoc.Imaginary - bottomRightLoc.Imaginary;
            return (int)Math.Ceiling(imagRange / delta) + 1;
        }
    }
}