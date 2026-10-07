using System.Numerics;

namespace FractalViewer.Fractals
{
    public class FractalImageParameters
    {
        public Complex TopLeftLocation, BottomRightLocation;
        public int NumRows, NumCols;
        public int MaxIterations;
        public double Delta;
        public FractalImageParameters(Complex topLeftLoc, Complex bottomRightLoc, int numRows, int numCols, int maxIterations)
        {
            TopLeftLocation = topLeftLoc;
            BottomRightLocation = bottomRightLoc;
            NumRows = numRows;
            NumCols = numCols;
            MaxIterations = maxIterations;
            Delta = GetDelta(TopLeftLocation, BottomRightLocation, NumRows, NumCols);
            Console.WriteLine(Delta);
        }

        private static double GetDelta(Complex topLeftLoc, Complex bottomRightLoc, int numRows, int numCols)
        {
            double realRange = bottomRightLoc.Real - topLeftLoc.Real;
            double imagRange = topLeftLoc.Imaginary - bottomRightLoc.Imaginary;
            return Math.Min(realRange / (numCols - 1), imagRange / (numRows - 1));
        }

        public Complex GetComplexAtPixel(int x, int y)
        {
            Complex complexDiff = new(Delta * x, -Delta * y);
            return TopLeftLocation + complexDiff;
        }
    }
}