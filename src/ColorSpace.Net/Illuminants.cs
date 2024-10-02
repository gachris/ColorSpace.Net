namespace ColorSpace.Net;

/// <summary>
/// Provides standard illuminants with 2-degree and 10-degree observer data.
/// </summary>
public class Illuminants
{
    /// <summary>
    /// Gets the A_2 illuminant (Incandescent/tungsten, 2-degree observer).
    /// </summary>
    public static Illuminant A_2 => GetIlluminant(nameof(A_2));

    /// <summary>
    /// Gets the B_2 illuminant (Old direct sunlight at noon, 2-degree observer).
    /// </summary>
    public static Illuminant B_2 => GetIlluminant(nameof(B_2));

    /// <summary>
    /// Gets the C_2 illuminant (Old daylight, 2-degree observer).
    /// </summary>
    public static Illuminant C_2 => GetIlluminant(nameof(C_2));

    /// <summary>
    /// Gets the D50_2 illuminant (ICC profile PCS, 2-degree observer).
    /// </summary>
    public static Illuminant D50_2 => GetIlluminant(nameof(D50_2));

    /// <summary>
    /// Gets the D55_2 illuminant (Mid-morning daylight, 2-degree observer).
    /// </summary>
    public static Illuminant D55_2 => GetIlluminant(nameof(D55_2));

    /// <summary>
    /// Gets the D65_2 illuminant (Daylight, sRGB, Adobe-RGB, 2-degree observer).
    /// </summary>
    public static Illuminant D65_2 => GetIlluminant(nameof(D65_2));

    /// <summary>
    /// Gets the D75_2 illuminant (North sky daylight, 2-degree observer).
    /// </summary>
    public static Illuminant D75_2 => GetIlluminant(nameof(D75_2));

    /// <summary>
    /// Gets the E_2 illuminant (Equal energy, 2-degree observer).
    /// </summary>
    public static Illuminant E_2 => GetIlluminant(nameof(E_2));

    /// <summary>
    /// Gets the F1_2 illuminant (Daylight Fluorescent, 2-degree observer).
    /// </summary>
    public static Illuminant F1_2 => GetIlluminant(nameof(F1_2));

    /// <summary>
    /// Gets the F2_2 illuminant (Cool fluorescent, 2-degree observer).
    /// </summary>
    public static Illuminant F2_2 => GetIlluminant(nameof(F2_2));

    /// <summary>
    /// Gets the F3_2 illuminant (White Fluorescent, 2-degree observer).
    /// </summary>
    public static Illuminant F3_2 => GetIlluminant(nameof(F3_2));

    /// <summary>
    /// Gets the F4_2 illuminant (Warm White Fluorescent, 2-degree observer).
    /// </summary>
    public static Illuminant F4_2 => GetIlluminant(nameof(F4_2));

    /// <summary>
    /// Gets the F5_2 illuminant (Daylight Fluorescent, 2-degree observer).
    /// </summary>
    public static Illuminant F5_2 => GetIlluminant(nameof(F5_2));

    /// <summary>
    /// Gets the F6_2 illuminant (Lite White Fluorescent, 2-degree observer).
    /// </summary>
    public static Illuminant F6_2 => GetIlluminant(nameof(F6_2));

    /// <summary>
    /// Gets the F7_2 illuminant (Daylight fluorescent, D65 simulator, 2-degree observer).
    /// </summary>
    public static Illuminant F7_2 => GetIlluminant(nameof(F7_2));

    /// <summary>
    /// Gets the F8_2 illuminant (Sylvania F40, D50 simulator, 2-degree observer).
    /// </summary>
    public static Illuminant F8_2 => GetIlluminant(nameof(F8_2));

    /// <summary>
    /// Gets the F9_2 illuminant (Cool White Fluorescent, 2-degree observer).
    /// </summary>
    public static Illuminant F9_2 => GetIlluminant(nameof(F9_2));

    /// <summary>
    /// Gets the F10_2 illuminant (Ultralume 50, Philips TL85, 2-degree observer).
    /// </summary>
    public static Illuminant F10_2 => GetIlluminant(nameof(F10_2));

    /// <summary>
    /// Gets the F11_2 illuminant (Ultralume 40, Philips TL84, 2-degree observer).
    /// </summary>
    public static Illuminant F11_2 => GetIlluminant(nameof(F11_2));

    /// <summary>
    /// Gets the F12_2 illuminant (Ultralume 30, Philips TL83, 2-degree observer).
    /// </summary>
    public static Illuminant F12_2 => GetIlluminant(nameof(F12_2));

    /// <summary>
    /// Gets the A_10 illuminant (Incandescent/tungsten, 10-degree observer).
    /// </summary>
    public static Illuminant A_10 => GetIlluminant(nameof(A_10));

    /// <summary>
    /// Gets the B_10 illuminant (Old direct sunlight at noon, 10-degree observer).
    /// </summary>
    public static Illuminant B_10 => GetIlluminant(nameof(B_10));

    /// <summary>
    /// Gets the C_10 illuminant (Old daylight, 10-degree observer).
    /// </summary>
    public static Illuminant C_10 => GetIlluminant(nameof(C_10));

    /// <summary>
    /// Gets the D50_10 illuminant (ICC profile PCS, 10-degree observer).
    /// </summary>
    public static Illuminant D50_10 => GetIlluminant(nameof(D50_10));

    /// <summary>
    /// Gets the D55_10 illuminant (Mid-morning daylight, 10-degree observer).
    /// </summary>
    public static Illuminant D55_10 => GetIlluminant(nameof(D55_10));

    /// <summary>
    /// Gets the D65_10 illuminant (Daylight, sRGB, Adobe-RGB, 10-degree observer).
    /// </summary>
    public static Illuminant D65_10 => GetIlluminant(nameof(D65_10));

    /// <summary>
    /// Gets the D75_10 illuminant (North sky daylight, 10-degree observer).
    /// </summary>
    public static Illuminant D75_10 => GetIlluminant(nameof(D75_10));

    /// <summary>
    /// Gets the E_10 illuminant (Equal energy, 10-degree observer).
    /// </summary>
    public static Illuminant E_10 => GetIlluminant(nameof(E_10));

    /// <summary>
    /// Gets the F1_10 illuminant (Daylight Fluorescent, 10-degree observer).
    /// </summary>
    public static Illuminant F1_10 => GetIlluminant(nameof(F1_10));

    /// <summary>
    /// Gets the F2_10 illuminant (Cool fluorescent, 10-degree observer).
    /// </summary>
    public static Illuminant F2_10 => GetIlluminant(nameof(F2_10));

    /// <summary>
    /// Gets the F3_10 illuminant (White Fluorescent, 10-degree observer).
    /// </summary>
    public static Illuminant F3_10 => GetIlluminant(nameof(F3_10));

    /// <summary>
    /// Gets the F4_10 illuminant (Warm White Fluorescent, 10-degree observer).
    /// </summary>
    public static Illuminant F4_10 => GetIlluminant(nameof(F4_10));

    /// <summary>
    /// Gets the F5_10 illuminant (Daylight Fluorescent, 10-degree observer).
    /// </summary>
    public static Illuminant F5_10 => GetIlluminant(nameof(F5_10));

    /// <summary>
    /// Gets the F6_10 illuminant (Lite White Fluorescent, 10-degree observer).
    /// </summary>
    public static Illuminant F6_10 => GetIlluminant(nameof(F6_10));

    /// <summary>
    /// Gets the F7_10 illuminant (Daylight fluorescent, D65 simulator, 10-degree observer).
    /// </summary>
    public static Illuminant F7_10 => GetIlluminant(nameof(F7_10));

    /// <summary>
    /// Gets the F8_10 illuminant (Sylvania F40, D50 simulator, 10-degree observer).
    /// </summary>
    public static Illuminant F8_10 => GetIlluminant(nameof(F8_10));

    /// <summary>
    /// Gets the F9_10 illuminant (Cool White Fluorescent, 10-degree observer).
    /// </summary>
    public static Illuminant F9_10 => GetIlluminant(nameof(F9_10));

    /// <summary>
    /// Gets the F10_10 illuminant (Ultralume 50, Philips TL85, 10-degree observer).
    /// </summary>
    public static Illuminant F10_10 => GetIlluminant(nameof(F10_10));

    /// <summary>
    /// Gets the F11_10 illuminant (Ultralume 40, Philips TL84, 10-degree observer).
    /// </summary>
    public static Illuminant F11_10 => GetIlluminant(nameof(F11_10));

    /// <summary>
    /// Gets the F12_10 illuminant (Ultralume 30, Philips TL83, 10-degree observer).
    /// </summary>
    public static Illuminant F12_10 => GetIlluminant(nameof(F12_10));

    /// <summary>
    /// Retrieves the specified illuminant from the collection.
    /// </summary>
    /// <param name="IlluminantKey">The key of the illuminant to retrieve.</param>
    /// <returns>The <see cref="Illuminant"/> corresponding to the specified key.</returns>
    internal static Illuminant GetIlluminant(string IlluminantKey) => _illuminants[IlluminantKey];

    /// <summary>
    /// Dictionary containing all the illuminants.
    /// </summary>
    private static readonly IDictionary<string, Illuminant> _illuminants = new Dictionary<string, Illuminant>
    {
        { nameof(A_2), new Illuminant(109.850, 100.000, 35.585, nameof(A_2), "Incandescent/tungsten") },
        { nameof(B_2), new Illuminant(99.0927, 100.000, 85.313, nameof(B_2), "Old direct sunlight at noon") },
        { nameof(C_2), new Illuminant(98.074, 100.000, 118.232, nameof(C_2), "Old daylight") },
        { nameof(D50_2), new Illuminant(96.422, 100.000, 82.521, nameof(D50_2), "ICC profile PCS") },
        { nameof(D55_2), new Illuminant(95.682, 100.000, 92.149, nameof(D55_2), "Mid-morning daylight") },
        { nameof(D65_2), new Illuminant(95.047, 100.000, 108.883, nameof(D65_2), "Daylight, sRGB, Adobe-RGB") },
        { nameof(D75_2), new Illuminant(94.972, 100.000, 122.638, nameof(D75_2), "North sky daylight") },
        { nameof(E_2), new Illuminant(100.000, 100.000, 100.000, nameof(E_2), "Equal energy") },
        { nameof(F1_2), new Illuminant(92.834, 100.000, 10.3665, nameof(F1_2), "Daylight Fluorescent") },
        { nameof(F2_2), new Illuminant(99.187, 100.000, 67.395, nameof(F2_2), "Cool fluorescent") },
        { nameof(F3_2), new Illuminant(103.754, 100.000, 49.861, nameof(F3_2), "White Fluorescent") },
        { nameof(F4_2), new Illuminant(109.147, 100.000, 38.813, nameof(F4_2), "Warm White Fluorescent") },
        { nameof(F5_2), new Illuminant(90.872, 100.000, 98.723, nameof(F5_2), "Daylight Fluorescent") },
        { nameof(F6_2), new Illuminant(97.309, 100.000, 60.191, nameof(F6_2), "Lite White Fluorescent") },
        { nameof(F7_2), new Illuminant(95.044, 100.000, 108.755, nameof(F7_2), "Daylight fluorescent, D65 simulator") },
        { nameof(F8_2), new Illuminant(96.413, 100.000, 82.333, nameof(F8_2), "Sylvania F40, D50 simulator") },
        { nameof(F9_2), new Illuminant(100.365, 100.000, 67.868, nameof(F9_2), "Cool White Fluorescent") },
        { nameof(F10_2), new Illuminant(96.174, 100.000, 81.712, nameof(F10_2), "Ultralume 50, Philips TL85") },
        { nameof(F11_2), new Illuminant(100.966, 100.000, 64.370, nameof(F11_2), "Ultralume 40, Philips TL84") },
        { nameof(F12_2), new Illuminant(108.046, 100.000, 39.228, nameof(F12_2), "Ultralume 30, Philips TL83") },
        { nameof(A_10), new Illuminant(111.144, 100.000, 35.200, nameof(A_10), "Incandescent/tungsten") },
        { nameof(B_10), new Illuminant(99.178, 100.000, 84.3493, nameof(B_10), "Old direct sunlight at noon") },
        { nameof(C_10), new Illuminant(97.285, 100.000, 116.145, nameof(C_10), "Old daylight") },
        { nameof(D50_10), new Illuminant(96.720, 100.000, 81.427, nameof(D50_10), "ICC profile PCS") },
        { nameof(D55_10), new Illuminant(95.799, 100.000, 90.926, nameof(D55_10), "Mid-morning daylight") },
        { nameof(D65_10), new Illuminant(94.811, 100.000, 107.304, nameof(D65_10), "Daylight, sRGB, Adobe-RGB") },
        { nameof(D75_10), new Illuminant(94.416, 100.000, 120.641, nameof(D75_10), "North sky daylight") },
        { nameof(E_10), new Illuminant(100.000, 100.000, 100.000, nameof(E_10), "Equal energy") },
        { nameof(F1_10), new Illuminant(94.791, 100.000, 103.191, nameof(F1_10), "Daylight Fluorescent") },
        { nameof(F2_10), new Illuminant(103.280, 100.000, 69.026, nameof(F2_10), "Cool fluorescent") },
        { nameof(F3_10), new Illuminant(108.968, 100.000, 51.965, nameof(F3_10), "White Fluorescent") },
        { nameof(F4_10), new Illuminant(114.961, 100.000, 40.963, nameof(F4_10), "Warm White Fluorescent") },
        { nameof(F5_10), new Illuminant(93.369, 100.000, 98.636, nameof(F5_10), "Daylight Fluorescent") },
        { nameof(F6_10), new Illuminant(102.148, 100.000, 62.074, nameof(F6_10), "Lite White Fluorescent") },
        { nameof(F7_10), new Illuminant(95.792, 100.000, 107.687, nameof(F7_10), "Daylight fluorescent, D65 simulator") },
        { nameof(F8_10), new Illuminant(97.115, 100.000, 81.135, nameof(F8_10), "Sylvania F40, D50 simulator") },
        { nameof(F9_10), new Illuminant(102.116, 100.000, 67.826, nameof(F9_10), "Cool White Fluorescent") },
        { nameof(F10_10), new Illuminant(99.001, 100.000, 83.134, nameof(F10_10), "Ultralume 50, Philips TL85") },
        { nameof(F11_10), new Illuminant(103.866, 100.000, 65.627, nameof(F11_10), "Ultralume 40, Philips TL84") },
        { nameof(F12_10), new Illuminant(111.428, 100.000, 40.353, nameof(F12_10), "Ultralume 30, Philips TL83") }
    };
}