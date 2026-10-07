using Raylib_cs;

namespace FractalViewer.UserInterface
{
    public class SelectionBox
    {
        int StartX, StartY, EndX, EndY;
        public SelectionBox()
        {
            StartX = -1;
            StartY = -1;
            EndX = -1; 
            EndY = -1;
        }

        public void StartAt(int x, int y)
        {
            StartX = x;
            StartY = y;
            EndX = x;
            EndY = y;
        }

        public void DragTo(int x, int y)
        {
            EndX = x;
            EndY = y;
        }

        public void Reset()
        {
            StartX = -1;
            StartY = -1;
            EndX = -1;
            EndY = -1;
        }

        public void Render()
        {
            int leftX = Math.Min(StartX, EndX);
            int rightX = Math.Max(StartX, EndX);
            int topY = Math.Min(StartY, EndY);
            int bottomY = Math.Max(StartY, EndY);
            Raylib.DrawRectangleLines(leftX, topY, rightX - leftX, bottomY - topY, Color.Green);
        }

        public override string ToString()
        {
            return $"SelectionBox: ({StartX}, {StartY}, {EndX}, {EndY})";
        }
    }
}