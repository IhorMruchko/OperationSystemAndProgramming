namespace TranslatorLIB.Operands;

public class Constant : Operand
{
    private int _constantValue;

    internal override bool CanCreate(string possibleOperandValue)
    {
        return true;
    }
}
