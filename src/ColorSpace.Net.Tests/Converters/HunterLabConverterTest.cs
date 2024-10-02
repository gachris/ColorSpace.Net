using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Converters;

public class HunterLabConverterTest
{
    private readonly IColorConverter<HunterLab> _converter_D65_2;
    private readonly IColorConverter<HunterLab> _converter_C_2;

    public static TheoryData<HunterLab, Cmy> DataCmy =>
       new()
       {
            { HunterLabColors.Amazon, CmyColors.Amazon },
            { HunterLabColors.CelestialBlue, CmyColors.CelestialBlue }
       };

    public static TheoryData<HunterLab, Cmyk> DataCmyk =>
        new()
        {
            { HunterLabColors.Amazon, CmykColors.Amazon },
            { HunterLabColors.CelestialBlue, CmykColors.CelestialBlue }
        };

    public static TheoryData<HunterLab, Hsl> DataHsl =>
        new()
        {
            { HunterLabColors.Amazon, HslColors.Amazon },
            { HunterLabColors.CelestialBlue, HslColors.CelestialBlue }
        };

    public static TheoryData<HunterLab, Hsv> DataHsv =>
        new()
        {
            { HunterLabColors.Amazon, HsvColors.Amazon },
            { HunterLabColors.CelestialBlue, HsvColors.CelestialBlue }
        };

    public static TheoryData<HunterLab, Lab> DataLab =>
        new()
        {
            { HunterLabColors.Amazon, LabColors.Amazon },
            { HunterLabColors.CelestialBlue, LabColors.CelestialBlue }
        };

    public static TheoryData<HunterLab, Lch> DataLch =>
        new()
        {
            { HunterLabColors.Amazon, LchColors.Amazon },
            { HunterLabColors.CelestialBlue, LchColors.CelestialBlue }
        };

    public static TheoryData<HunterLab, Luv> DataLuv =>
        new()
        {
            { HunterLabColors.Amazon, LuvColors.Amazon },
            { HunterLabColors.CelestialBlue, LuvColors.CelestialBlue }
        };

    public static TheoryData<HunterLab, Rgb> DataRgb =>
        new()
        {
            { HunterLabColors.Amazon, RgbColors.Amazon },
            { HunterLabColors.CelestialBlue, RgbColors.CelestialBlue }
        };

    public static TheoryData<HunterLab, Xyz> DataXyz =>
        new()
        {
            { HunterLabColors.Amazon, XyzColors.Amazon },
            { HunterLabColors.CelestialBlue, XyzColors.CelestialBlue }
        };

    public static TheoryData<HunterLab, Yxy> DataYxy =>
        new()
        {
            { HunterLabColors.Amazon, YxyColors.Amazon },
            { HunterLabColors.CelestialBlue, YxyColors.CelestialBlue }
        };

    public HunterLabConverterTest()
    {
        _converter_D65_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.D65_2 })
                                     .ToColor<HunterLab>()
                                     .Build();

        _converter_C_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.C_2 })
                                     .ToColor<HunterLab>()
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
    [MemberData(nameof(DataYxy))]
    public void Convert_D65_2(HunterLab output, IColor color)
    {
        var convertedColor = _converter_D65_2.ConvertFrom(color);
        var areClose = HunterLab.AreClose(output, convertedColor);

        Assert.True(areClose);
    }

    [Theory]
    [MemberData(nameof(DataRgb))]
    [MemberData(nameof(DataXyz))]
    public void Convert_C_2(HunterLab output, IColor color)
    {
        var convertedColor = _converter_C_2.ConvertFrom(color);
        var areClose = HunterLab.AreClose(convertedColor, output);

        Assert.True(areClose);
    }
}