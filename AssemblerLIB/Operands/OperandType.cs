namespace TranslatorLIB.Operands;

public enum OperandType : byte
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
