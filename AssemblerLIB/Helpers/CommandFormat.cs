using System.Text;
using TranslatorLIB.Operands;

namespace TranslatorLIB.Helpers;

public class CommandFormat
{
    public OperandType FirstOperandType { get; set; }

    public OperandType SecondOperandType { get; set; }

    public string FormatLine { get; set; } = string.Empty;

    public CommandFormat(OperandType firstOperandType, OperandType secondOperandType, string formatLine)
    {
        FirstOperandType = firstOperandType;
        SecondOperandType = secondOperandType;
        FormatLine = new StringBuilder(formatLine.Trim())
            .Replace(Constants.Operands.SEGMENT_DEFAULT, Constants.Format.S_VAlUE)
            .ToString();
    }

    public string GetFormat(Operand first, Operand second)
    {
        if (first.OperandTypes.Contains(FirstOperandType) == false
            || second.OperandTypes.Contains(SecondOperandType) == false)
        {
            return string.Empty;
        }
        return new StringBuilder(FormatLine)
            .Replace(Constants.Operands.W_DEFAULT, first.W)
            .Replace(Constants.Operands.W_DEFAULT, second.W)
            .Replace(Constants.Operands.REGISTER_DEFAULT, first.Register)
            .Replace(Constants.Operands.REGISTER_DEFAULT, first.Register)
            .Replace(Constants.Operands.REGISTER_OR_MEMORY_DEFAULT, first.RegisterOrMemory)
            .Replace(Constants.Operands.REGISTER_OR_MEMORY_DEFAULT, first.RegisterOrMemory)
            .Replace(Constants.Operands.MOD_DEFAULT, first.Mod)
            .Replace(Constants.Operands.MOD_DEFAULT, second.Mod)
            .Replace(Constants.Operands.IMMEDIATE8_DEFAULT, first.Im8)
            .Replace(Constants.Operands.IMMEDIATE8_DEFAULT, second.Im8)
            .Replace(Constants.Operands.IMMEDIATE16_DEFAULT, first.Im16)
            .Replace(Constants.Operands.IMMEDIATE16_DEFAULT, second.Im16)
            .Replace(Constants.Operands.SEGMENT_REGISTER_DEFAULT, first.SegmentRegister)
            .Replace(Constants.Operands.SEGMENT_REGISTER_DEFAULT, second.SegmentRegister)
            .Replace(Constants.Format.COND, Constants.Format.COND_VALUE)
            .Replace(Constants.Format.D, Constants.Format.D_VALUE)
            .Replace(Constants.Format.COND_VALUE, Constants.Format.COND)
            .ToString();
    }
}
