namespace TranslatorLIB.Operands;

/// <summary>
/// Represents abstract class of the assembler operand.
/// </summary>
public abstract class Operand
{
    /// <summary>
    /// Value of the Immediate 8 bytes in the operand format.
    /// </summary>
    internal string Im8 { get; set; } = Constants.Operands.IMMEDIATE8_DEFAULT;

    /// <summary>
    /// Value of the Immediate 16 bytes in the operand format.
    /// </summary>
    internal string Im16 { get; set; } = Constants.Operands.IMMEDIATE16_DEFAULT;

    /// <summary>
    /// Value of the registers bytes in the operand format.
    /// </summary>
    internal string Register { get; set; } = Constants.Operands.REGISTER_DEFAULT;

    /// <summary>
    /// Value of the operand target: <br/>
    /// <c>w = 0</c>: command is working with bytes ;<br/>
    /// <c>w - 1</c>: command is working with words or doubled words;<br/>
    /// </summary>
    internal string W { get; set; } = Constants.Operands.W_DEFAULT;

    /// <summary>
    /// Value of the operand working source.
    /// </summary>
    internal string RegisterOrMemory { get; set; } = Constants.Operands.REGISTER_OR_MEMORY_DEFAULT;

    /// <summary>
    /// Value of the operand mod.
    /// </summary>
    internal string Mod { get; set; } = Constants.Operands.MOD_DEFAULT;

    /// <summary>
    /// Value of the operand segment source.
    /// </summary>
    internal string Segment { get; set; } = Constants.Operands.SEGMENT_DEFAULT;

    /// <summary>
    /// Value of the operand segment register source. 
    /// </summary>
    internal string SegmentRegister { get; set; } = Constants.Operands.SEGMENT_REGISTER_DEFAULT;

    /// <summary>
    /// Operand types that used in the command.
    /// </summary>
    internal List<Operands> OperandTypes { get; set; } = new List<Operands>();

    /// <summary>
    /// Defines weather operand can be created.
    /// </summary>
    /// <param name="possibleOperandValue">Value to set to the operand.</param>
    /// <returns>
    /// <c>true</c> - if operand is able to be created with <paramref name="possibleOperandValue"/>. <br/>
    /// <c>false</c> - otherwise.
    /// </returns>
    internal abstract bool CanCreate(string possibleOperandValue);

}
