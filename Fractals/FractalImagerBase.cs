namespace FractalViewer.Fractals
{
    public abstract class FractalImagerBase
    {
        protected FractalInfo FractalInfo;
        protected FractalImageParameters? ImageParams;
        public FractalImagerBase(FractalInfo fractalInfo)
        {
            FractalInfo = fractalInfo;
        }

        public abstract void CalculateData(int[,] dataBuffer);
        public void SetImageParams(FractalImageParameters imageParams)
        {
            ImageParams = imageParams;
        }
    }
}