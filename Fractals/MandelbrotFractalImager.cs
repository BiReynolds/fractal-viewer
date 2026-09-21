using System.Numerics;

namespace FractalViewer.Fractals
{
    public class MandelbrotFractalImager
    {
        public FractalInfo FractalInfo;
        public FractalImageParameters ImageParams;
        FractalImageData? ImageData;
        public MandelbrotFractalImager(FractalInfo fractalInfo, FractalImageParameters frameParams)
        {
            FractalInfo = fractalInfo;
            ImageParams = frameParams;
        }

        void CalculateData()
        {
            FractalPoint[,] rawData = new FractalPoint[ImageParams.NumRows, ImageParams.NumCols];
            for (int row = 0; row < ImageParams.NumRows; row++)
            {
                for (int col = 0; col < ImageParams.NumCols; col++)
                {
                    Complex locationOffset = new(col * ImageParams.Delta, -row * ImageParams.Delta);
                    Complex location = ImageParams.TopLeftLocation + locationOffset;
                    int escapeIndex = FractalInfo.GetEscapeIndex(0, location, ImageParams.MaxIterations);
                    rawData[row, col] = new FractalPoint(location, escapeIndex);
                }
            }
            ImageData = new(rawData, ImageParams.NumRows, ImageParams.NumCols);
        }

        public FractalImageData GetFractalImageData()
        {
            if (ImageData is null)
            {
                CalculateData();
            }
            return ImageData;
        }
    }
}