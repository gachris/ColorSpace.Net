using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Colors;

public class RgbTest
{
    [Fact]
    public void ParseScRgb()
    {
        var r = 0.0307134446f;
        var g = 0.205078736f;
        var b = 0.116970673f;

        var color = Rgb.FromScRgb(r, g, b);

        Assert.Equal(RgbColors.Amazon.R, color.R);
        Assert.Equal(RgbColors.Amazon.G, color.G);
        Assert.Equal(RgbColors.Amazon.B, color.B);

        Assert.Equal(RgbColors.Amazon.ScR, color.ScR);
        Assert.Equal(RgbColors.Amazon.ScG, color.ScG);
        Assert.Equal(RgbColors.Amazon.ScB, color.ScB);
    }

    [Fact]
    public void ParseRgb()
    {
        var r = (byte)49;
        var g = (byte)125;
        var b = (byte)96;

        var color = Rgb.FromRgb(r, g, b);

        Assert.Equal(RgbColors.Amazon.R, color.R);
        Assert.Equal(RgbColors.Amazon.G, color.G);
        Assert.Equal(RgbColors.Amazon.B, color.B);

        Assert.Equal(RgbColors.Amazon.ScR, color.ScR);
        Assert.Equal(RgbColors.Amazon.ScG, color.ScG);
        Assert.Equal(RgbColors.Amazon.ScB, color.ScB);
    }
}