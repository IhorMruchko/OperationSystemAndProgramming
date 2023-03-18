using TranslatorLIB.Helpers;

namespace TranslatorLIB.Operands;

/// <summary>
/// Represents constant value as an operand of the command.
/// </summary>
public class Constant : Operand
{
    /// <summary>
    /// Value that parsed from the line.
    /// </summary>
    public int ConstantValue { get; private set; }

    internal override bool CanCreate(string possibleOperandValue)
        => FormatValidator.IsConstant(possibleOperandValue)
        || FormatValidator.IsStringConstant(possibleOperandValue);

    public Constant() : base() { }

    /// <summary>
    /// Instantiates constant with <paramref name="line"/> data and <paramref name="bytes"/>.
    /// </summary>
    /// <param name="line">Value of the constant.</param>
    /// <param name="bytes">Defines type of operand. <br/>
    /// if <paramref name="bytes"/> = 1 sets <see cref="OperandType.Immediate8"/>; <br/>
    /// if <paramref name="bytes"/> = 2 sets <see cref="OperandType.Immediate16"/>.
    /// </param>
    public Constant(string line, int bytes)
    {
        ConstantValue = line.StartsWith(Constants.Converting.CONSTANTS_SIGN, StringComparison.InvariantCultureIgnoreCase)
            ? line[Constants.Converting.VALUE_INDEX]
            : AsmConverter.ToNumber(line);

        Im8 = AsmConverter.ExpandTo(AsmConverter.DecimalToBase(ConstantValue,
                                                               Constants.Converting.BINARY_BASE),
                                    Constants.Converting.BIT);
        Im16 = AsmConverter.ExpandTo(AsmConverter.DecimalToBase(ConstantValue,
                                                                Constants.Converting.BINARY_BASE),
                                     Constants.Converting.TWO_BITS);

        OperandTypes.Add(Im8.Length <= 8 && bytes == Constants.Converting.BIT
            ? OperandType.Immediate8
            : OperandType.Immediate16);
    }
}
