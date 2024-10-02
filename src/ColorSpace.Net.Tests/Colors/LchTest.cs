using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Colors;

public class LchTest
{
    [Fact]
    public void ParseLch()
    {
        var l = 47.189868224870494m;
        var c = 32.12001091321291m;
        var h = 163.87672383227132m;

        var color = Lch.FromLch(l, c, h);

        Assert.Equal(LchColors.Amazon.L, color.L);
        Assert.Equal(LchColors.Amazon.C, color.C);
        Assert.Equal(LchColors.Amazon.H, color.H);
    }
}