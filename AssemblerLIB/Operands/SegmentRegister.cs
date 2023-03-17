using TranslatorLIB.Helpers;

namespace TranslatorLIB.Operands;

/// <summary>
/// Represents segment register as operand in command.
/// </summary>
public class SegmentRegister : Operand
{
    public SegmentRegister() : base() { }

    public SegmentRegister(string line)
    {
        SegmentRegister = GetCode(line.ToUpper());
        OperandTypes.Add(Operands.SegmentRegister);
    }

    internal override bool CanCreate(string possibleOperandValue)
        => FormatValidator.IsSegmentRegister(possibleOperandValue.ToUpper());

    /// <summary>
    /// Defines proper <see cref="Operand.SegmentRegister"/>.
    /// </summary>
    /// <param name="possibleOperandValue">Value of the segment register.</param>
    /// <returns>
    /// Proper value for <see cref="Operand.SegmentRegister"/>.
    /// </returns>
    /// <exception cref="CompileError"><paramref name="possibleOperandValue"/> is not an segment register value.</exception>
    private static string GetCode(string possibleOperandValue)
    {
        if (Constants.Register.REGISTER_TO_BINARY.ContainsKey(possibleOperandValue))
        {
            return Constants.Register.REGISTER_TO_BINARY[possibleOperandValue];
        }
        throw CompileError.SegmentRegisterNotFound(possibleOperandValue);
    }
}
