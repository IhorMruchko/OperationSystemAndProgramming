using TranslatorLIB.Helpers;

namespace TranslatorLIB.Operands;

/// <summary>
/// Represents register as an operand in the command.
/// </summary>
public class Register : Operand
{
    public Register() : base() { }

    public Register(string line)
    {
        InitRegister(line);
    }

    /// <summary>
    /// Sets register operand type as <see cref="OperandType.RegisterOrMemory"/> if <paramref name="isRegisterOnly"/> is <c>false</c>.
    /// </summary>
    /// <param name="line">Value to set in the register.</param>
    /// <param name="isRegisterOnly">Defines is register type is <see cref="OperandType.Register"/> only or also <see cref="OperandType.RegisterOrMemory"/>.</param>
    public Register(string line, bool isRegisterOnly)
    {
        InitRegister(line);
        if (isRegisterOnly == false)
        {
            RegisterOrMemory = Register;
            Mod = Constants.Register.MOD;
            OperandTypes.Add(OperandType.RegisterOrMemory);
        }
    }
    internal override bool CanCreate(string possibleOperandValue)
        => FormatValidator.IsRegister(possibleOperandValue);

    /// <summary>
    /// Initialize register based on registers values.
    /// </summary>
    /// <param name="line">Value of the register.</param>
    /// <remarks>
    /// If <paramref name="line"/> starts with <see cref="Constants.Register.A"/> adds <see cref="OperandType.RegisterAx"/>. <br/>
    /// If <paramref name="line"/> equals to <see cref="Constants.Register.CL"/> adds <see cref="OperandType.RegisterCL"/>.
    /// </remarks>
    private void InitRegister(string line)
    {
        (Register, W) = GetRegisterCode(line);
        OperandTypes.Add(OperandType.Register);
        if (line.StartsWith(Constants.Register.A, StringComparison.InvariantCultureIgnoreCase))
        {
            OperandTypes.Add(OperandType.RegisterAx);
        }
        if (line.Equals(Constants.Register.CL, StringComparison.InvariantCultureIgnoreCase))
        {
            OperandTypes.Add(OperandType.RegisterCL);
        }
    }

    /// <summary>
    /// Defines register code.
    /// </summary>
    /// <param name="line">Value of the register.</param>
    /// <returns>
    /// Proper value for <see cref="Operand.Register"/>. <br/>
    /// Proper value for <see cref="Operand.W"/>.
    /// </returns>
    private static (string register, string w) GetRegisterCode(string line)
    {
        var w = line.Contains(Constants.Register.L, StringComparison.InvariantCultureIgnoreCase)
            || line.Contains(Constants.Register.H, StringComparison.InvariantCultureIgnoreCase)
            ? Constants.Register.ZERO
            : Constants.Register.ONE;
        if (Constants.Register.REGISTER_TO_BINARY.ContainsKey(line.ToUpper()))
        {
            return (Constants.Register.REGISTER_TO_BINARY[line.ToUpper()], w);
        }

        throw CompileError.RegisterNotFound(line);
    }
}
