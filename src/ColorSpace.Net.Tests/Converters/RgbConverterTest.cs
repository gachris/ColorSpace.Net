using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Converters;

public class RgbConverterTest
{
    private readonly IColorConverter<Rgb> _converter_D65_2;
    private readonly IColorConverter<Rgb> _converter_C_2;

    public static TheoryData<Rgb, Cmy> DataCmy =>
       new()
       {
            { RgbColors.Amazon, CmyColors.Amazon },
            { RgbColors.CelestialBlue, CmyColors.CelestialBlue }
       };

    public static TheoryData<Rgb, Cmyk> DataCmyk =>
        new()
        {
            { RgbColors.Amazon, CmykColors.Amazon },
            { RgbColors.CelestialBlue, CmykColors.CelestialBlue }
        };

    public static TheoryData<Rgb, Hsl> DataHsl =>
        new()
        {
            { RgbColors.Amazon, HslColors.Amazon },
            { RgbColors.CelestialBlue, HslColors.CelestialBlue }
        };

    public static TheoryData<Rgb, Hsv> DataHsv =>
        new()
        {
            { RgbColors.Amazon, HsvColors.Amazon },
            { RgbColors.CelestialBlue, HsvColors.CelestialBlue }
        };

    public static TheoryData<Rgb, HunterLab> DataHunterLab =>
        new()
        {
            { RgbColors.Amazon, HunterLabColors.Amazon },
            { RgbColors.CelestialBlue, HunterLabColors.CelestialBlue }
        };

    public static TheoryData<Rgb, Lab> DataLab =>
        new()
        {
            { RgbColors.Amazon, LabColors.Amazon },
            { RgbColors.CelestialBlue, LabColors.CelestialBlue }
        };

    public static TheoryData<Rgb, Lch> DataLch =>
        new()
        {
            { RgbColors.Amazon, LchColors.Amazon },
            { RgbColors.CelestialBlue, LchColors.CelestialBlue }
        };

    public static TheoryData<Rgb, Luv> DataLuv =>
        new()
        {
            { RgbColors.Amazon, LuvColors.Amazon },
            { RgbColors.CelestialBlue, LuvColors.CelestialBlue }
        };

    public static TheoryData<Rgb, Xyz> DataXyz =>
        new()
        {
            { RgbColors.Amazon, XyzColors.Amazon },
            { RgbColors.CelestialBlue, XyzColors.CelestialBlue }
        };

    public static TheoryData<Rgb, Yxy> DataYxy =>
        new()
        {
            { RgbColors.Amazon, YxyColors.Amazon },
            { RgbColors.CelestialBlue, YxyColors.CelestialBlue }
        };

    public RgbConverterTest()
    {
        _converter_D65_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.D65_2 })
            .ToColor<Rgb>()
            .Build();

        _converter_C_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.C_2 })
            .ToColor<Rgb>()
            .Build();
    }

    [Theory]
    [MemberData(nameof(DataCmy))]
    [MemberData(nameof(DataCmyk))]
    [MemberData(nameof(DataHsl))]
    [MemberData(nameof(DataHsv))]
    [MemberData(nameof(DataLab))]
    [MemberData(nameof(DataLch))]
    [MemberData(nameof(DataLuv))]
    [MemberData(nameof(DataXyz))]
    [MemberData(nameof(DataYxy))]
    public void Convert_D65_2(Rgb output, IColor color)
    {
        var convertedColor = _converter_D65_2.ConvertFrom(color);
        var areClose = Rgb.AreClose(output, convertedColor);

        Assert.True(areClose);
    }

    [Theory]
    [MemberData(nameof(DataHunterLab))]
    public void Convert_C_2(Rgb output, IColor color)
    {
        var convertedColor = _converter_C_2.ConvertFrom(color);
        var areClose = Rgb.AreClose(convertedColor, output);

        Assert.True(areClose);
    }
}