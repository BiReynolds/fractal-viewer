using System.Numerics;
using FractalViewer.Fractals;
using FractalViewer.Input;
using FractalViewer.Input.RawInput;
using FractalViewer.Rendering;
using FractalViewer.UserInterface;

namespace FractalViewer
{
    public class FractalViewerProgram
    {
        FractalWindow Window;
        UIManager UIManager = new();
        FractalInputManager InputManager = new();
        FractalImageParameters ImageParams;
        FractalImagerBase Imager;
        FractalArtist Artist;
        FractalImageData? CurrentImage;
        public FractalViewerProgram(int screenWidth, int screenHeight, 
                                    Complex topLeft, Complex bottomRight, int maxIterations, 
                                    FractalImagerBase imager, IFractalColorizer colorizer)
        {
            Window = new(screenWidth, screenHeight);
            ImageParams = new(topLeft, bottomRight, screenWidth, maxIterations);
            Imager = imager;
            Imager.SetImageParams(ImageParams);
            Artist = new(colorizer);
        }

        public void Start()
        {
            RegisterEvents();
            CurrentImage = Imager.GetFractalImageData();
            Window.InitWindow();
            Window.SetTargetFPS(60);
            while (!Window.WindowShouldClose())
            {
                InputManager.CheckEvents();

                Window.BeginDrawing();
                Window.ClearBackground();

                Artist.DrawFractalImage(CurrentImage);
                UIManager.Render();

                Window.EndDrawing();
            }

            Window.CloseWindow();
        }
        
        private void RegisterEvents()
        {
            InputManager.SelectionStarted += (o, e) => { UIManager.SelectionBox.StartAt(e.StartX, e.StartY); };
            InputManager.SelectionEnded += (o, e) => { UIManager.SelectionBox.Reset(); };
            InputManager.SelectionChanged += (o, e) => {UIManager.SelectionBox.DragTo(e.EndX, e.EndY); };

            InputManager.SelectionEnded += (o, e) => { 
                RecalculateImageData(e); 
            };
        }

        private async void RecalculateImageData(SelectionEventArgs e)
        {
            Console.WriteLine("Recalculating Image Data...");
            e.GetSelectionInfo(out int left, out int top, out int bottom, out int right);
            Complex newTopLeft = CurrentImage.GetLocationAtPixel(left, top);
            Complex newBottomRight = CurrentImage.GetLocationAtPixel(right, bottom);
            ImageParams = new(newTopLeft, newBottomRight, ImageParams.NumRows, ImageParams.MaxIterations);
            Imager.SetImageParams(ImageParams);
            CurrentImage = null;
            CurrentImage = Imager.GetFractalImageData();
            Console.WriteLine("Image Data Recalculated");
        }
    }
}