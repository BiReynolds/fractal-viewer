namespace FractalViewer.UserInterface
{
    public class UIManager
    {
        public SelectionBox SelectionBox = new();
        public void Render()
        {
            SelectionBox.Render();
        }
    }
}