using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Converters;

public class YxyConverterTest
{
    private readonly IColorConverter<Yxy> _converter_D65_2;
    private readonly IColorConverter<Yxy> _converter_C_2;

    public static TheoryData<Yxy, Cmy> DataCmy =>
       new()
       {
            { YxyColors.Amazon, CmyColors.Amazon },
            { YxyColors.CelestialBlue, CmyColors.CelestialBlue }
       };

    public static TheoryData<Yxy, Cmyk> DataCmyk =>
        new()
        {
            { YxyColors.Amazon, CmykColors.Amazon },
            { YxyColors.CelestialBlue, CmykColors.CelestialBlue }
        };

    public static TheoryData<Yxy, Hsl> DataHsl =>
        new()
        {
            { YxyColors.Amazon, HslColors.Amazon },
            { YxyColors.CelestialBlue, HslColors.CelestialBlue }
        };

    public static TheoryData<Yxy, Hsv> DataHsv =>
        new()
        {
            { YxyColors.Amazon, HsvColors.Amazon },
            { YxyColors.CelestialBlue, HsvColors.CelestialBlue }
        };

    public static TheoryData<Yxy, HunterLab> DataHunterLab =>
        new()
        {
            { YxyColors.Amazon, HunterLabColors.Amazon },
            { YxyColors.CelestialBlue, HunterLabColors.CelestialBlue }
        };

    public static TheoryData<Yxy, Lab> DataLab =>
        new()
        {
            { YxyColors.Amazon, LabColors.Amazon },
            { YxyColors.CelestialBlue, LabColors.CelestialBlue }
        };

    public static TheoryData<Yxy, Lch> DataLch =>
        new()
        {
            { YxyColors.Amazon, LchColors.Amazon },
            { YxyColors.CelestialBlue, LchColors.CelestialBlue }
        };

    public static TheoryData<Yxy, Luv> DataLuv =>
        new()
        {
            { YxyColors.Amazon, LuvColors.Amazon },
            { YxyColors.CelestialBlue, LuvColors.CelestialBlue }
        };

    public static TheoryData<Yxy, Rgb> DataRgb =>
        new()
        {
            { YxyColors.Amazon, RgbColors.Amazon },
            { YxyColors.CelestialBlue, RgbColors.CelestialBlue }
        };

    public static TheoryData<Yxy, Xyz> DataXyz =>
        new()
        {
            { YxyColors.Amazon, XyzColors.Amazon },
            { YxyColors.CelestialBlue, XyzColors.CelestialBlue }
        };

    public YxyConverterTest()
    {
        _converter_D65_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.D65_2 })
            .ToColor<Yxy>()
            .Build();

        _converter_C_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.C_2 })
            .ToColor<Yxy>()
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
    [MemberData(nameof(DataRgb))]
    [MemberData(nameof(DataXyz))]
    public void Convert_D65_2(Yxy output, IColor color)
    {
        var convertedColor = _converter_D65_2.ConvertFrom(color);
        var areClose = Yxy.AreClose(output, convertedColor);

        Assert.True(areClose);
    }

    [Theory]
    [MemberData(nameof(DataHunterLab))]
    public void Convert_C_2(Yxy output, IColor color)
    {
        var convertedColor = _converter_C_2.ConvertFrom(color);
        var areClose = Yxy.AreClose(convertedColor, output);

        Assert.True(areClose);
    }
}