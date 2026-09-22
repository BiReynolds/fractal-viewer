using System.Numerics;
using FractalViewer.Fractals;
using FractalViewer.Rendering;

namespace FractalViewer
{
    public class FractalViewerProgram
    {
        FractalWindow Window;
        FractalImagerBase Imager;
        FractalArtist Artist;
        public FractalViewerProgram(int screenWidth, int screenHeight, 
                                    Complex topLeft, Complex bottomRight, int maxIterations, 
                                    FractalImagerBase imager, IFractalColorizer colorizer)
        {
            Window = new(screenWidth, screenHeight);
            FractalImageParameters imageParams = new(topLeft, bottomRight, screenWidth, maxIterations);
            Imager = imager;
            Imager.SetImageParams(imageParams);
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