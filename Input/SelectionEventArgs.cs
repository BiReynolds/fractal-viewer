namespace FractalViewer.Input
{
    public class SelectionEventArgs : EventArgs
    {
        public int StartX, StartY, EndX, EndY;
        public SelectionEventArgs(int startX, int startY, int endX, int endY)
        {
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }
    }
}