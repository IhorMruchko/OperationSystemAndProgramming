using System.Globalization;
using System.Text.RegularExpressions;

namespace TranslatorLIB.Helpers;

public static class FormatValidator
{
    private static readonly Regex _stringConstantValidator = new("\".\"");
    public static bool IsConstant(string possibleConstant)
    {
        if (possibleConstant.EndsWith(Constants.Converting.HEX_BASE_SIGN, StringComparison.InvariantCultureIgnoreCase)
            && int.TryParse(possibleConstant[..^1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _))
        {
            return true;
        }
        if (possibleConstant.EndsWith(Constants.Converting.BINARY_BASE_SIGN, StringComparison.InvariantCultureIgnoreCase) &&
            IsBinary(possibleConstant))
        {
            return true;
        }
        return int.TryParse(possibleConstant, out _);
    }

    public static bool IsStringConstant(string possibleConstant)
    {
        return _stringConstantValidator.IsMatch(possibleConstant);
    }

    public static bool IsRegister(string possibleOperandValue)
    {
        possibleOperandValue = possibleOperandValue.ToUpper();
        return Constants.Register.OPERATION_REGISTERS.Contains(possibleOperandValue)
            || Constants.Register.ADRESS_REGISTERS.Contains(possibleOperandValue);
    }

    private static bool IsBinary(string possibleBinary)
    {
        try
        {
            _ = AsmConverter.FromBaseToDecimal(possibleBinary[..^1], Constants.Converting.BINARY_BASE);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool IsSegmentRegister(string possibleSegmentRegister)
        => Constants.Register.SEGMENT_REGISTERS.Contains(possibleSegmentRegister);

    public static bool IsAddress(string possibleAddress)
        => Constants.Register.ADRESS_REGISTERS.Contains(possibleAddress);
}
