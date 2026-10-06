namespace FractalViewer.Rendering.UserInterface
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
            Console.WriteLine($"Selection started at {x}, {y}");
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
            Console.WriteLine($"value before reset {this}");
            StartX = -1;
            StartY = -1;
            EndX = -1;
            EndY = -1;
        }

        public override string ToString()
        {
            return $"SelectionBox: ({StartX}, {StartY}, {EndX}, {EndY})";
        }
    }
}