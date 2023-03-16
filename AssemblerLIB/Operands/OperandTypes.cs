namespace TranslatorLIB.Operands;

public enum OperandTypes : byte
{
    RegisterOrMemory,
    Register,
    Immediate8,
    Memory,
    RegisterAx,
    None,
    Immediate16,
    SegmentRegister,
    RegisterCL
}
