namespace ColorSpace.Net.Helpers;

internal static class FloatHelpers
{
    private static readonly float FLT_EPSILON = 1.192092896e-07F;

    public static bool AreClose(float a, float b)
    {
        if (a == b) return true;
        // This computes (|a-b| / (|a| + |b| + 10.0f)) < FLT_EPSILON
        float eps = ((float)Math.Abs(a) + (float)Math.Abs(b) + 10.0f) * FLT_EPSILON;
        float delta = a - b;
        return -eps < delta && eps > delta;
    }
}