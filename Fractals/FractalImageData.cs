using System.Numerics;

namespace FractalViewer.Fractals
{
    public class FractalImageData
    {
        public int NumRows, NumCols;
        public int[,] Data;
        public FractalImageData(int numRows, int numCols)
        {
            Data = new int[numRows, numCols];
            NumRows = numRows;
            NumCols = numCols;
        }
    }
}