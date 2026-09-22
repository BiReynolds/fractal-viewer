using System.Numerics;
using Raylib_cs;
using FractalViewer;
using FractalViewer.Fractals;
using FractalViewer.Rendering;

public static class Program
{
    static Complex TopLeft = new(-2, 2);
    static Complex BottomRight = new(2, -2);
    static int NumRows = 1000;
    static int NumCols = 1000;
    static int MaxIterations = 100;
    public static void Main()
    {
        FractalInfo fractalInfo = GetMandelbrotInfo();
        IFractalColorizer colorizer = new GradientColorizer(Color.Black, Color.White, MaxIterations, 0.2);
        FractalImagerBase imager = new JuliaFractalImager(new Complex(-0.5, -0.5), fractalInfo);
        FractalViewerProgram viewer = new(NumRows, NumCols, TopLeft, BottomRight, MaxIterations, imager, colorizer);
        viewer.Start();
    }

    static FractalInfo GetMandelbrotInfo()
    {
        return new FractalInfo(QuadraticIterator, 2);
    }

    static Complex QuadraticIterator(Complex iteratingVariable, Complex parameter)
    {
        return iteratingVariable * iteratingVariable + parameter;
    }
}