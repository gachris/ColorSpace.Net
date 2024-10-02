using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Colors;

public class YxyConverterTest
{
    [Fact]
    public void ParseYxy()
    {
        var y1 = 16.164727261615358m;
        var x = 0.26449492304110866m;
        var y2 = 0.39914716973741265m;

        var color = Yxy.FromYxy(y1, x, y2);

        Assert.Equal(YxyColors.Amazon.Y1, color.Y1);
        Assert.Equal(YxyColors.Amazon.X, color.X);
        Assert.Equal(YxyColors.Amazon.Y2, color.Y2);
    }
}