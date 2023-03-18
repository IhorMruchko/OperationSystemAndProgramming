namespace TranslatorLIB.Operands;

/// <summary>
/// Defines null operand for commands that takes zero operands.
/// </summary>
public class NullOperand : Operand
{
    public NullOperand(string line)
    {
        OperandTypes.Add(OperandType.None);
    }

    internal override bool CanCreate(string possibleOperandValue)
    {
        return true;
    }
}
