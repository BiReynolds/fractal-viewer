using Raylib_cs;

namespace FractalViewer.Rendering
{
    public class FractalWindow
    {
        const string Title = "Fractal Viewer";
        public int WindowWidth, WindowHeight;
        public Color BackgroundColor = Color.Black;
        public FractalWindow(int windowWidth, int windowHeight)
        {
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
        }

        public void InitWindow()
        {
            Raylib.InitWindow(WindowWidth, WindowHeight, Title);
        }

        public void SetTargetFPS(int fps)
        {
            Raylib.SetTargetFPS(fps);
        }

        public void BeginDrawing()
        {
            Raylib.BeginDrawing();
        }

        public void EndDrawing()
        {
            Raylib.EndDrawing();
        }

        public void ClearBackground()
        {
            Raylib.ClearBackground(BackgroundColor);
        }

        public bool WindowShouldClose()
        {
            return Raylib.WindowShouldClose();
        }

        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }
    }
}