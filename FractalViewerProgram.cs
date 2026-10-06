using System.Numerics;
using FractalViewer.Fractals;
using FractalViewer.Input;
using FractalViewer.Input.RawInput;
using FractalViewer.Rendering;
using FractalViewer.Rendering.UserInterface;

namespace FractalViewer
{
    public class FractalViewerProgram
    {
        FractalWindow Window;
        UIManager UIManager = new();
        FractalInputManager InputManager = new();
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
            RegisterEvents();
            FractalImageData image = Imager.GetFractalImageData();
            Window.InitWindow();
            Window.SetTargetFPS(10);
            while (!Window.WindowShouldClose())
            {
                Window.BeginDrawing();
                Window.ClearBackground();

                Artist.DrawFractalImage(image);

                InputManager.CheckEvents();

                Window.EndDrawing();
            }

            Window.CloseWindow();
        }
        
        public void RegisterEvents()
        {
            InputManager.SelectionStarted += (o, e) => { UIManager.SelectionBox.StartAt(e.StartX, e.StartY); };
            InputManager.SelectionEnded += (o, e) => { UIManager.SelectionBox.DragTo(e.EndX, e.EndY); };
        }
    }
}