namespace FractalViewer.Fractals
{
    public class FractalImageData
    {
        public int NumRows, NumCols;
        public FractalPoint[,] Data;
        public FractalImageData(FractalPoint[,] data, int numRows, int numCols)
        {
            Data = data;
            NumRows = numRows;
            NumCols = numCols;
        }

        public int[,] GetEscapeData()
        {
            int[,] result = new int[NumRows, NumCols];
            for (int row = 0; row < NumRows; row++)
            {
                for (int col = 0; col < NumCols; col++)
                {
                    result[row, col] = Data[row, col].EscapeIndex;
                }
            }
            return result;
        }
    }
}