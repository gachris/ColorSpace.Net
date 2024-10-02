namespace ColorSpace.Net;

/// <summary>
/// Represents the options for color conversion.
/// </summary>
public class ColorConverterOptions
{
    /// <summary>
    /// Gets or sets the illuminant used for color conversion.
    /// </summary>
    public Illuminant Illuminant { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorConverterOptions"/> class.
    /// </summary>
    public ColorConverterOptions()
    {
        // Set the default illuminant to D65_2
        Illuminant = Illuminants.D65_2;
    }
}
