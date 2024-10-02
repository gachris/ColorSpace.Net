using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Colors;

public class LuvTest
{
    [Fact]
    public void ParseLuv()
    {
        var l = 47.189868224870494m;
        var u = -31.97898099901001m;
        var v = 16.208655339897803m;

        var color = Luv.FromLuv(l, u, v);

        Assert.Equal(LuvColors.Amazon.L, color.L);
        Assert.Equal(LuvColors.Amazon.U, color.U);
        Assert.Equal(LuvColors.Amazon.V, color.V);
    }
}