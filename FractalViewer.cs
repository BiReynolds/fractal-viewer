using System.Numerics;
using FractalViewer.Fractals;
using FractalViewer.Rendering;

namespace FractalViewer
{
    public class FractalViewerProgram
    {
        FractalWindow Window;
        MandelbrotFractalImager Imager;
        FractalArtist Artist;
        public FractalViewerProgram(int screenWidth, int screenHeight, Complex topLeft, Complex bottomRight, FractalInfo fractalInfo, int maxIterations, IFractalColorizer colorizer)
        {
            Window = new(screenWidth, screenHeight);
            FractalImageParameters frameParams = new(topLeft, bottomRight, screenWidth, maxIterations);
            Imager = new(fractalInfo, frameParams);
            Artist = new(colorizer);
        }

        public void Start()
        {
            FractalImageData image = Imager.GetFractalImageData();

            Window.InitWindow();
            Window.SetTargetFPS(10);
            while (!Window.WindowShouldClose())
            {
                Window.BeginDrawing();
                Window.ClearBackground();

                Artist.DrawFractalImage(image);

                Window.EndDrawing();
            }

            Window.CloseWindow();
        }
    }
}