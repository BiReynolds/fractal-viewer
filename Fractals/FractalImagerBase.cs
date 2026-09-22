namespace FractalViewer.Fractals
{
    public abstract class FractalImagerBase
    {
        protected FractalInfo FractalInfo;
        protected FractalImageParameters? ImageParams;
        protected FractalImageData? ImageData;
        public FractalImagerBase(FractalInfo fractalInfo)
        {
            FractalInfo = fractalInfo;
        }

        protected abstract void CalculateData(); // must set ImageData!!!
        public void SetImageParams(FractalImageParameters imageParams)
        {
            ImageParams = imageParams;
        }
        public virtual FractalImageData GetFractalImageData()
        {
            if (ImageData == null)
            {
                CalculateData();
            }
            return ImageData;
        }
    }
}