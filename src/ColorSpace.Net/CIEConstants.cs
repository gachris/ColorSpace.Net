namespace ColorSpace.Net;

/// <summary>
/// Static class containing constants related to the CIE color space.
/// </summary>
internal static class CIEConstants
{
    /// <summary>
    /// Epsilon constant used in CIE color space calculations.
    /// </summary>
    public const double Epsilon = 216d / 24389d;

    /// <summary>
    /// Kappa constant used in CIE color space calculations.
    /// </summary>
    public const double Kappa = 24389d / 27d;
}
