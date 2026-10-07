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
    static int MaxIterations = 50;
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
        // The mandelbrot iteration has the property that if z is ever a distance > 2 from the origin, that sequence necessarily diverges.  
        return new FractalInfo(QuadraticIterator, x => 2);
    }

    static FractalInfo GetQuadraticJuliaInfo()
    {
        // Julia sets have a slightly more complicated escape radius logic - a radius R which guarantees divergence must satisfy that R^2 - R > magnitude(c)
        // Here, we increment by 0.1 until we find such a radius
        return new FractalInfo(QuadraticIterator, c =>
        {
            double testRadius = 0.1;
            while (testRadius * testRadius - testRadius < c.Magnitude)
            {
                testRadius += 0.1;
            }
            return testRadius;
        });
    }

    static Complex QuadraticIterator(Complex iteratingVariable, Complex parameter)
    {
        return iteratingVariable * iteratingVariable + parameter;
    }
}