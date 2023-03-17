using TranslatorLIB.Extensions;
using System.Text;
using static System.Math;

namespace TranslatorLIB.Helpers;

public static class AsmConverter
{
    public static string DecimalToBase(int decimalNumber, int newBase)
    {
        var bytes = new int[Constants.Converting.DECIMAL_CAPACITY];
        var result = new StringBuilder();
        var currentBytesPointer = Constants.Converting.DECIMAL_CAPACITY;

        for (; decimalNumber > 0; decimalNumber /= newBase)
        {
            var currentModulus = decimalNumber % newBase;
            bytes[--currentBytesPointer] = currentModulus;
        }

        for (var i = 0; i < bytes.Length; ++i)
        {
            result.Append(bytes[i] >= Constants.Converting.DECIMAL_BASE
                ? Constants.Converting.HEX_VALUES_SYMBOLS[bytes[i] % Constants.Converting.DECIMAL_BASE]
                : bytes[i]);
        }

        return result.Remove(0, currentBytesPointer).ToString();
    }

    public static int ToPositive(int number, int bytes)
        => number < 0
        ? (int)Round(Pow(Constants.Converting.OCT_BITS, bytes)) + number
        : number;

    public static int ToNumber(string number)
    {
        if (number.Equals(Constants.Converting.UNKNOW_VALUE))
        {
            return 0;
        }

        if (number.EndsWith(Constants.Converting.HEX_BASE_SIGN, StringComparison.InvariantCultureIgnoreCase))
        {
            return FromBaseToDecimal(number[..^1], Constants.Converting.HEX_BASE);
        }

        if (number.EndsWith(Constants.Converting.BINARY_BASE_SIGN, StringComparison.InvariantCultureIgnoreCase))
        {
            return FromBaseToDecimal(number[..^1], Constants.Converting.BINARY_BASE);
        }

        if (int.TryParse(number, out var result))
        {
            return result;
        }

        throw CompileError.WrongNumberFormat(number);
    }

    public static int FromBaseToDecimal(string number, int oldBase)
    {
        var result = 0;
        var currentParsedBytes = 1;
        var hexValues = string.Empty;
        if (oldBase > Constants.Converting.DECIMAL_BASE)
        {
            hexValues = "".JoinString(Constants.Converting.HEX_VALUES_SYMBOLS);
        }

        for (var i = number.Length - 1; i >= 0; --i, currentParsedBytes *= oldBase)
        {
            var currentValue = number[i].ToString();
            var currentByte = currentValue.IndexOfAny(Constants.Converting.HEX_VALUES_SYMBOLS) >= 0
                ? Constants.Converting.HEX_VALUES[hexValues.IndexOf(number[i])]
                : number[i] - Constants.Converting.ASCII_CHARSET_DIFFERENCE;
            result += currentByte * currentParsedBytes;
        }

        return result;
    }

    public static string ExpandTo(string line, int bytes)
    {
        var normalizedLine = line.NormalizeStart(Constants.Converting.LEADING_ZEROES,
                                                 bytes * Constants.Converting.BITS_IN_BYTE);
        if (bytes == 2)
        {
            normalizedLine = string.Concat(normalizedLine.AsSpan(Constants.Converting.BITS_IN_BYTE, Constants.Converting.BITS_IN_BYTE),
                                           normalizedLine.AsSpan(0, Constants.Converting.BITS_IN_BYTE));
        }

        return normalizedLine;

    }
}
