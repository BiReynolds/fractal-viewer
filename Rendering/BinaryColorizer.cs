using Raylib_cs;

namespace FractalViewer.Rendering
{
    public class BinaryColorizer : IFractalColorizer
    {
        public Color OnColor;
        public Color OffColor;
        public BinaryColorizer(Color onColor, Color offColor)
        {
            OnColor = onColor;
            OffColor = offColor;
        }

        public Color GetColorFromEscapeIndex(int escapeIndex)
        {
            if (escapeIndex == -1)
            {
                return OnColor;
            }
            else
            {
                return OffColor;
            }
        }
    }
}