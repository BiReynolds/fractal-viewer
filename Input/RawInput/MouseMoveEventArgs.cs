namespace FractalViewer.Input.RawInput
{
    public class MouseMoveEventArgs : EventArgs
    {
        public int DeltaX, DeltaY, NewX, NewY;
        public MouseMoveEventArgs(int deltaX, int deltaY, int newX, int newY)
        {
            DeltaX = deltaX;
            DeltaY = deltaY;
            NewX = newX;
            NewY = newY;
        }
    }
}