namespace TranslatorLIB.Operands;

public abstract class Operand
{
    internal string Im8 { get; set; } = string.Empty;

    internal string Im16 { get; set; } = string.Empty;

    internal string Register { get; set; } = string.Empty;

    internal string W { get; set; } = string.Empty;

    internal string RegisterOrMemory { get; set; } = string.Empty;

    internal string Mod { get; set; } = string.Empty;

    internal string Segment { get; set; } = string.Empty;

    internal string SegmentRegister { get; set; } = string.Empty;

    internal List<OperandTypes> OperandTypes { get; set; } = new List<OperandTypes>();

    internal abstract bool CanCreate(string possibleOperandValue);

}
