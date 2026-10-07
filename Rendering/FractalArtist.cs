using Raylib_cs;
using FractalViewer.Fractals;

namespace FractalViewer.Rendering
{
    public class FractalArtist
    {
        IFractalColorizer Colorizer;
        public FractalArtist(IFractalColorizer colorizer)
        {
            Colorizer = colorizer;
        }

        public void DrawFractalImage(FractalImageData? imageData)
        {
            if (imageData == null)
            {
                Console.WriteLine("Recalculating Image...");
            }
            else
            {
                for (int row = 0; row < imageData.NumRows; row++)
                {
                    for (int col = 0; col < imageData.NumCols; col++)
                    {
                        int escapeIndex = imageData.Data[row, col].EscapeIndex;
                        Color pixelColor = Colorizer.GetColorFromEscapeIndex(escapeIndex);
                        Raylib.DrawPixel(col, row, pixelColor);
                    }
                }
            }
        }
    }
}