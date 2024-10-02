using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Converters;

public class HsvConverterTest
{
    private readonly IColorConverter<Hsv> _converter_D65_2;
    private readonly IColorConverter<Hsv> _converter_C_2;

    public static TheoryData<Hsv, Cmy> DataCmy =>
       new()
       {
            { HsvColors.Amazon, CmyColors.Amazon },
            { HsvColors.CelestialBlue, CmyColors.CelestialBlue }
       };

    public static TheoryData<Hsv, Cmyk> DataCmyk =>
        new()
        {
            { HsvColors.Amazon, CmykColors.Amazon },
            { HsvColors.CelestialBlue, CmykColors.CelestialBlue }
        };

    public static TheoryData<Hsv, Hsl> DataHsl =>
        new()
        {
            { HsvColors.Amazon, HslColors.Amazon },
            { HsvColors.CelestialBlue, HslColors.CelestialBlue }
        };

    public static TheoryData<Hsv, HunterLab> DataHunterLab =>
        new()
        {
            { HsvColors.Amazon, HunterLabColors.Amazon },
            { HsvColors.CelestialBlue, HunterLabColors.CelestialBlue }
        };

    public static TheoryData<Hsv, Lab> DataLab =>
        new()
        {
            { HsvColors.Amazon, LabColors.Amazon },
            { HsvColors.CelestialBlue, LabColors.CelestialBlue }
        };

    public static TheoryData<Hsv, Lch> DataLch =>
        new()
        {
            { HsvColors.Amazon, LchColors.Amazon },
            { HsvColors.CelestialBlue, LchColors.CelestialBlue }
        };

    public static TheoryData<Hsv, Luv> DataLuv =>
        new()
        {
            { HsvColors.Amazon, LuvColors.Amazon },
            { HsvColors.CelestialBlue, LuvColors.CelestialBlue }
        };

    public static TheoryData<Hsv, Rgb> DataRgb =>
        new()
        {
            { HsvColors.Amazon, RgbColors.Amazon },
            { HsvColors.CelestialBlue, RgbColors.CelestialBlue }
        };

    public static TheoryData<Hsv, Xyz> DataXyz =>
        new()
        {
            { HsvColors.Amazon, XyzColors.Amazon },
            { HsvColors.CelestialBlue, XyzColors.CelestialBlue }
        };

    public static TheoryData<Hsv, Yxy> DataYxy =>
        new()
        {
            { HsvColors.Amazon, YxyColors.Amazon },
            { HsvColors.CelestialBlue, YxyColors.CelestialBlue }
        };

    public HsvConverterTest()
    {
        _converter_D65_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.D65_2 })
            .ToColor<Hsv>()
            .Build();

        _converter_C_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.C_2 })
            .ToColor<Hsv>()
            .Build();
    }

    [Theory]
    [MemberData(nameof(DataCmy))]
    [MemberData(nameof(DataCmyk))]
    [MemberData(nameof(DataHsl))]
    [MemberData(nameof(DataLab))]
    [MemberData(nameof(DataLch))]
    [MemberData(nameof(DataLuv))]
    [MemberData(nameof(DataRgb))]
    [MemberData(nameof(DataXyz))]
    [MemberData(nameof(DataYxy))]
    public void Convert_D65_2(Hsv output, IColor color)
    {
        var convertedColor = _converter_D65_2.ConvertFrom(color);
        var areClose = Hsv.AreClose(output, convertedColor);

        Assert.True(areClose);
    }

    [Theory]
    [MemberData(nameof(DataHunterLab))]
    public void Convert_C_2(Hsv output, IColor color)
    {
        var convertedColor = _converter_C_2.ConvertFrom(color);
        var areClose = Hsv.AreClose(convertedColor, output);

        Assert.True(areClose);
    }
}