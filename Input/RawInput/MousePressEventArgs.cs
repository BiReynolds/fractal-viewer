using Raylib_cs;

namespace FractalViewer.Input.RawInput
{
    public class MousePressEventArgs : EventArgs
    {
        public MouseButton Button;
        public int X, Y;
        public MousePressEventArgs(MouseButton button, int x, int y)
        {
            Button = button;
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            string result = $"Mouse Button Pressed | ";
            result += $"Button: {Button} | ";
            result += $"(X, Y): ({X}, {Y}) | ";
            return result;
        }
    }
}