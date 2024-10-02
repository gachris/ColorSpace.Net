using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Colors;

public class XyzTest
{
    [Fact]
    public void ParseXyz()
    {
        var x = 10.711558585907511m;
        var y = 16.164727261615358m;
        var z = 13.621877454623712m;

        var color = Xyz.FromXyz(x, y, z);

        Assert.Equal(XyzColors.Amazon.X, color.X);
        Assert.Equal(XyzColors.Amazon.Y, color.Y);
        Assert.Equal(XyzColors.Amazon.Z, color.Z);
    }
}