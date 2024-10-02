namespace ColorSpace.Net.Helpers;

internal static class DoubleHelpers
{
    public static double Fxyz(double t)
    {
        return t > 0.008856 ? Math.Pow(t, 1.0 / 3.0) : 7.787 * t + 16.0 / 116.0;
    }

    public static double DegreeToRadian(double angle)
    {
        return Math.PI * angle / 180.0;
    }

    public static double PivotXyz(double n)
    {
        return n > 0.008856 ? Math.Pow(n, 1.0 / 3.0) : (903.3 * n + 16) / 116;
    }
}