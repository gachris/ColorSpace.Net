using System.Globalization;

namespace ColorSpace.Net.Helpers;

internal static class FormatProviderHelper
{
    public static char GetNumericListSeparator(IFormatProvider? provider)
    {
        var numericSeparator = ',';
        var numberFormat = NumberFormatInfo.GetInstance(provider);

        if (numberFormat.NumberDecimalSeparator.Length > 0 && numericSeparator == numberFormat.NumberDecimalSeparator[0])
        {
            numericSeparator = ';';
        }

        return numericSeparator;
    }
}