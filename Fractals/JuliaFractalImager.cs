using System.Numerics;

namespace FractalViewer.Fractals
{
    public class JuliaFractalImager : FractalImagerBase
    {
        Complex ParameterValue;
        public JuliaFractalImager(Complex parameterValue, FractalInfo fractalInfo) : base(fractalInfo)
        {
            ParameterValue = parameterValue;
        }
        public override void CalculateData(int[,] dataBuffer)
        {
            if (ImageParams == null)
            {
                throw new Exception("FractalImager: Tried to calculate data without setting ImageParams");
            }
            Console.WriteLine("Calculating image data");
            Console.WriteLine($"ImageParams Rows/Cols: {ImageParams.NumRows}, {ImageParams.NumCols}");
            Console.WriteLine($"dataBuffer Rows/Cols: {dataBuffer.GetLength(0)}, {dataBuffer.GetLength(1)}");
            for (int row = 0; row < ImageParams.NumRows; row++)
            {
                for (int col = 0; col < ImageParams.NumCols; col++)
                {
                    Complex locationOffset = new(col * ImageParams.Delta, -row * ImageParams.Delta);
                    Complex location = ImageParams.TopLeftLocation + locationOffset;
                    int escapeIndex = FractalInfo.GetEscapeIndex(location, ParameterValue, ImageParams.MaxIterations);
                    dataBuffer[row, col] = escapeIndex;
                }
            }
            Console.WriteLine("done");
        }
    }
}