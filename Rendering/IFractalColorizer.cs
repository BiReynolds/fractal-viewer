using Raylib_cs;

namespace FractalViewer.Rendering
{
    public interface IFractalColorizer
    {
        public Color GetColorFromEscapeIndex(int escapeIndex);
    }
}