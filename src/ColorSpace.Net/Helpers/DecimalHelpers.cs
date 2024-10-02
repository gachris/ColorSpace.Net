namespace ColorSpace.Net.Helpers;

internal static class DecimalHelpers
{
    private static readonly float FLT_EPSILON = 1.192092896e-07F;

    public static bool AreClose(decimal a, decimal b)
    {
        if (a == b) return true;
        var eps = (Math.Abs(a) + Math.Abs(b) + 10.0m) * (decimal)FLT_EPSILON;
        var delta = a - b;
        return -eps < delta && eps > delta;
    }

    public static decimal RestrictToRange(decimal number, decimal min, decimal max)
    {
        return Math.Min(Math.Max(number, min), max);
    }

    public static byte RestrictToByte(decimal number)
    {
        return (byte)Math.Round(RestrictToRange(number, 0m, 255m));
    }
}