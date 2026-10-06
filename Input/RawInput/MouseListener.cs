using Raylib_cs;

namespace FractalViewer.Input.RawInput
{
    public class MouseListener
    {
        public event EventHandler<MousePressEventArgs>? PressEvent;
        public event EventHandler<MouseReleaseEventArgs>? ReleaseEvent;
        public void CheckEvents()
        {
            CheckMousePressEvents();
            CheckMouseReleaseEvents();
        }
        
        void CheckMousePressEvents()
        {
            foreach (var button in Enum.GetValues<MouseButton>())
            {
                if (Raylib.IsMouseButtonPressed(button))
                {
                    PressEvent_Raised(button, Raylib.GetMouseX(), Raylib.GetMouseY());
                }
            }
        }

        void CheckMouseReleaseEvents()
        {
            foreach (var button in Enum.GetValues<MouseButton>())
            {
                if (Raylib.IsMouseButtonReleased(button))
                {
                    
                }
            }
        }

        void PressEvent_Raised(MouseButton button, int x, int y)
        {
            if (PressEvent is null)
            {
                return;
            }
            else
            {
                MousePressEventArgs eventArgs = new(button, x, y);
                PressEvent.Invoke(this, eventArgs);
            }
        }

        void ReleaseEvent_Raised(MouseButton button, int x, int y)
        {
            if (ReleaseEvent is null)
            {
                return;
            }
            else
            {
                MouseReleaseEventArgs eventArgs = new(button, x, y);
                ReleaseEvent.Invoke(this, eventArgs);
            }
        }
    }
}