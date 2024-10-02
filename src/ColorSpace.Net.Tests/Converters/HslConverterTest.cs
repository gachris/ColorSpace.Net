using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Converters;

public class HslConverterTest
{
    private readonly IColorConverter<Hsl> _converter_D65_2;
    private readonly IColorConverter<Hsl> _converter_C_2;

    public static TheoryData<Hsl, Cmy> DataCmy =>
        new()
        {
            { HslColors.Amazon, CmyColors.Amazon },
            { HslColors.CelestialBlue, CmyColors.CelestialBlue }
        };

    public static TheoryData<Hsl, Cmyk> DataCmyk =>
        new()
        {
            { HslColors.Amazon, CmykColors.Amazon },
            { HslColors.CelestialBlue, CmykColors.CelestialBlue }
        };

    public static TheoryData<Hsl, Hsv> DataHsv =>
        new()
        {
            { HslColors.Amazon, HsvColors.Amazon },
            { HslColors.CelestialBlue, HsvColors.CelestialBlue }
        };

    public static TheoryData<Hsl, HunterLab> DataHunterLab =>
        new()
        {
            { HslColors.Amazon, HunterLabColors.Amazon },
            { HslColors.CelestialBlue, HunterLabColors.CelestialBlue }
        };

    public static TheoryData<Hsl, Lab> DataLab =>
        new()
        {
            { HslColors.Amazon, LabColors.Amazon },
            { HslColors.CelestialBlue, LabColors.CelestialBlue }
        };

    public static TheoryData<Hsl, Lch> DataLch =>
        new()
        {
            { HslColors.Amazon, LchColors.Amazon },
            { HslColors.CelestialBlue, LchColors.CelestialBlue }
        };

    public static TheoryData<Hsl, Luv> DataLuv =>
        new()
        {
            { HslColors.Amazon, LuvColors.Amazon },
            { HslColors.CelestialBlue, LuvColors.CelestialBlue }
        };

    public static TheoryData<Hsl, Rgb> DataRgb =>
        new()
        {
            { HslColors.Amazon, RgbColors.Amazon },
            { HslColors.CelestialBlue, RgbColors.CelestialBlue }
        };

    public static TheoryData<Hsl, Xyz> DataXyz =>
        new()
        {
            { HslColors.Amazon, XyzColors.Amazon },
            { HslColors.CelestialBlue, XyzColors.CelestialBlue }
        };

    public static TheoryData<Hsl, Yxy> DataYxy =>
        new()
        {
            { HslColors.Amazon, YxyColors.Amazon },
            { HslColors.CelestialBlue, YxyColors.CelestialBlue }
        };

    public HslConverterTest()
    {
        _converter_D65_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.D65_2 })
            .ToColor<Hsl>()
            .Build();

        _converter_C_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.C_2 })
            .ToColor<Hsl>()
            .Build();
    }

    [Theory]
    [MemberData(nameof(DataCmy))]
    [MemberData(nameof(DataCmyk))]
    [MemberData(nameof(DataHsv))]
    [MemberData(nameof(DataLab))]
    [MemberData(nameof(DataLch))]
    [MemberData(nameof(DataLuv))]
    [MemberData(nameof(DataRgb))]
    [MemberData(nameof(DataXyz))]
    [MemberData(nameof(DataYxy))]
    public void Convert_D65_2(Hsl output, IColor color)
    {
        var convertedColor = _converter_D65_2.ConvertFrom(color);
        var areClose = Hsl.AreClose(output, convertedColor);

        Assert.True(areClose);
    }

    [Theory]
    [MemberData(nameof(DataHunterLab))]
    public void Convert_C_2(Hsl output, IColor color)
    {
        var convertedColor = _converter_C_2.ConvertFrom(color);
        var areClose = Hsl.AreClose(convertedColor, output);

        Assert.True(areClose);
    }
}