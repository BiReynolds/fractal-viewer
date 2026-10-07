using System.Numerics;
using Raylib_cs;

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

        public void GetSelectionInfo(out int left, out int top, out int right, out int bottom)
        {
            left = Math.Min(StartX, EndX);
            top = Math.Min(StartY, EndY);
            right = Math.Max(StartX, EndX);
            bottom = Math.Max(StartY, EndY);
        }
    }
}