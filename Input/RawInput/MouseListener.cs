using System.Numerics;
using Raylib_cs;

namespace FractalViewer.Input.RawInput
{
    public class MouseListener
    {
        public event EventHandler<MousePressEventArgs>? PressEvent;
        public event EventHandler<MouseReleaseEventArgs>? ReleaseEvent;
        public event EventHandler<MouseMoveEventArgs>? MoveEvent;
        public void CheckEvents()
        {
            CheckMousePressEvents();
            CheckMouseReleaseEvents();
            CheckMouseMove();
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
                    ReleaseEvent_Raised(button, Raylib.GetMouseX(), Raylib.GetMouseY());
                }
            }
        }

        void CheckMouseMove()
        {
            Vector2 delta = Raylib.GetMouseDelta();
            if (delta.LengthSquared() == 0)
            {
                return;
            }
            else
            {
                MoveEvent_Raised((int)delta.X, (int)delta.Y, Raylib.GetMouseX(), Raylib.GetMouseY());
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

        void MoveEvent_Raised(int deltaX, int deltaY, int newX, int newY)
        {
            if (MoveEvent == null)
            {
                return;
            }
            else
            {
                MouseMoveEventArgs eventArgs = new(deltaX, deltaY, newX, newY);
                MoveEvent.Invoke(this, eventArgs);
            }
        }
    }
}