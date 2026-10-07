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
        protected override void CalculateData()
        {
            if (ImageParams == null)
            {
                throw new Exception("FractalImager: Tried to calculate data without setting ImageParams");
            }
            FractalPoint[,] rawData = new FractalPoint[ImageParams.NumRows, ImageParams.NumCols];

            for (int row = 0; row < ImageParams.NumRows; row++)
            {
                for (int col = 0; col < ImageParams.NumCols; col++)
                {
                    Complex locationOffset = new(col * ImageParams.Delta, -row * ImageParams.Delta);
                    Complex location = ImageParams.TopLeftLocation + locationOffset;
                    int escapeIndex = FractalInfo.GetEscapeIndex(location, ParameterValue, ImageParams.MaxIterations);
                    rawData[row, col] = new FractalPoint(location, escapeIndex);
                }
            }
            
            ImageData = new(rawData, ImageParams.NumRows, ImageParams.NumCols);
        }

        protected override void RecalculateData()
        {
            
        }
    }
}