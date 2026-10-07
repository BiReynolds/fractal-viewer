using System.Numerics;

namespace FractalViewer.Fractals
{
    public class MandelbrotFractalImager : FractalImagerBase
    {
        public MandelbrotFractalImager(FractalInfo fractalInfo) : base(fractalInfo) {}
        public override void CalculateData(int[,] dataBuffer)
        {
            if (ImageParams == null)
            {
                throw new Exception("FractalImager: Tried to calculate data without setting ImageParams");
            }

            for (int row = 0; row < ImageParams.NumRows; row++)
            {
                for (int col = 0; col < ImageParams.NumCols; col++)
                {
                    Complex locationOffset = new(col * ImageParams.Delta, -row * ImageParams.Delta);
                    Complex location = ImageParams.TopLeftLocation + locationOffset;
                    int escapeIndex = FractalInfo.GetEscapeIndex(0, location, ImageParams.MaxIterations);
                    dataBuffer[row, col] = escapeIndex;
                }
            }
        }
    }
}