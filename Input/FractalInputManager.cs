using System.Numerics;
using Raylib_cs;
using FractalViewer.Input.RawInput;

namespace FractalViewer.Input
{
    public class FractalInputManager
    {
        public event EventHandler<SelectionEventArgs>? SelectionStarted;
        public event EventHandler<SelectionEventArgs>? SelectionEnded;
        public event EventHandler<SelectionEventArgs>? SelectionChanged;
        bool IsSelecting;
        MouseListener MouseListener = new();
        int SelectionStartX = -1;
        int SelectionStartY = -1;
        public FractalInputManager()
        {
            MouseListener.PressEvent += HandleMousePressEvent;
            MouseListener.ReleaseEvent += HandleMouseReleaseEvent;
            MouseListener.MoveEvent += HandleMouseMoveEvent;
        }

        void SelectionStarted_Raised(int x, int y)
        {
            if (SelectionStarted == null)
            {
                return;
            }
            else
            {
                SelectionEventArgs eventArgs = new(x, y, x, y);
                SelectionStarted.Invoke(this, eventArgs);
            }
        }

        void SelectionEnded_Raised(int x, int y)
        {
            if (SelectionEnded == null)
            {
                return;
            }
            else
            {
                SelectionEventArgs eventArgs = new(SelectionStartX, SelectionStartY, x, y);
                SelectionEnded.Invoke(this, eventArgs);
            }
        }

        void SelectionChanged_Raised(int x, int y)
        {
            if (SelectionChanged == null)
            {
                return;
            }
            else
            {
                SelectionEventArgs eventArgs = new(SelectionStartX, SelectionStartY, x, y);
                SelectionChanged.Invoke(this, eventArgs);
            }
        }

        public void CheckEvents()
        {
            MouseListener.CheckEvents();
        }

        void HandleMousePressEvent(object? o, MousePressEventArgs e)
        {
            if (!IsSelecting)
            {
                if (e.Button == MouseButton.Left)
                {
                    StartAreaSelection(e.X, e.Y);
                }
                else if (e.Button == MouseButton.Right)
                {
                    Console.WriteLine("Right click (not yet implemeneted)");
                }
            }
            else if (IsSelecting && e.Button == MouseButton.Right)
            {
                CancelAreaSelection();
            }
        }

        void HandleMouseReleaseEvent(object? o, MouseReleaseEventArgs e)
        {
            if (IsSelecting && e.Button == MouseButton.Left)
            {
                EndAreaSelection(e.X, e.Y);
            }
        }

        void HandleMouseMoveEvent(object? o, MouseMoveEventArgs e)
        {
            if (IsSelecting)
            {
                SelectionChanged_Raised(e.NewX, e.NewY);
            }
        }

        void StartAreaSelection(int x, int y)
        {
            SelectionStarted_Raised(x, y);
            IsSelecting = true;
            SelectionStartX = x;
            SelectionStartY = y;
        }

        void EndAreaSelection(int x, int y)
        {
            SelectionEnded_Raised(x, y);
            IsSelecting = false;
            SelectionStartX = -1;
            SelectionStartY = -1;
        }

        void CancelAreaSelection()
        {
            IsSelecting = false;
            SelectionStartX = -1;
            SelectionStartY = -1;
        }
    }
}