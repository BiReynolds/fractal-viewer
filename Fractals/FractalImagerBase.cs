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
        protected abstract void RecalculateData(); // Used to avoid reallocating a large array
        public void SetImageParams(FractalImageParameters imageParams)
        {
            ImageParams = imageParams;
            CalculateData();
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