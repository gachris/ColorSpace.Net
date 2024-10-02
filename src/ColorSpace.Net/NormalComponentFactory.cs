using ColorSpace.Net.Componentes;

namespace ColorSpace.Net;

/// <summary>
/// Factory class for creating instances of normal components.
/// </summary>
public class NormalComponentFactory
{
    /// <summary>
    /// Creates a normal component based on the specified type.
    /// </summary>
    /// <param name="normalComponentType">The type of normal component to create.</param>
    /// <returns>An instance of the specified normal component.</returns>
    public static INormalComponent CreateNormalComponent(NormalComponentType normalComponentType)
    {
        return normalComponentType switch
        {
            NormalComponentType.Hsv_H => new HsvHueComponent(),
            NormalComponentType.Hsv_S => new HsvSaturationComponent(),
            NormalComponentType.Hsv_V => new HsvValueComponent(),
            NormalComponentType.Lab_L => new LabLComponent(),
            NormalComponentType.Lab_A => new LabAComponent(),
            NormalComponentType.Lab_B => new LabBComponent(),
            NormalComponentType.Rgb_R => new RgbRedComponent(),
            NormalComponentType.Rgb_G => new RgbGreenComponent(),
            NormalComponentType.Rgb_B => new RgbBlueComponent(),
            _ => throw new ArgumentException($"Conversion to {normalComponentType} not supported."),
        };
    }
}
