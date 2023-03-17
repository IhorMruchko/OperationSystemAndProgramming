using TranslatorLIB.Extensions;
using TranslatorLIB.Helpers;

namespace TranslatorLIB.Operands;

/// <summary>
/// Defines address as operand.
/// </summary>
public class Address : Operand
{
    /// <summary>
    /// Value of the address offset.
    /// </summary>
    internal int Offset { get; set; }

    /// <summary>
    /// String value of the address.
    /// </summary>
    internal string AddressStringValue { get; set; } = string.Empty;

    public Address() : base() { }

    /// <summary>
    /// Initiates values of the address.
    /// </summary>
    /// <param name="line">Value of the address.</param>
    public Address(string line)
    {
        line = line.ToUpper().ReplaceAll(Constants.Address.CLOSED_OPEN_RACKETS, Constants.Address.CLOSE_BRACKETS);
        var parts = HandleParts(line.Split(Constants.Address.LINE_SEPARATORS,
                                           Constants.Address.PARTS_AMOUNT,
                                           StringSplitOptions.RemoveEmptyEntries));
        if (parts.Length == 1)
        {
            HandleParts(parts[0]);
        }
        if (parts.Length == 2)
        {
            HandleParts(parts[0], parts[1]);
        }
        if (parts.Length == 3)
        {
            HandleParts(parts[0], parts[1], parts[2]);
        }
        OperandTypes.AddRange(new[] { Operands.RegisterOrMemory, Operands.Memory });
    }

    internal override bool CanCreate(string possibleOperandValue)
    {
        return true;
    }

    /// <summary>
    /// Sets proper value for <see cref="Address.Offset"/> and <see cref="Address.AddressStringValue"/> as constants.
    /// </summary>
    /// <param name="address">Value of the address.</param>
    /// <returns>
    /// <c>true</c> - if address contains proper constant values. <br/>
    /// <c>false</c> - otherwise.
    /// </returns>
    private bool Dispose(string address)
    {
        Mod = Constants.Address.MOD;
        if (address.StartsWith(Constants.Address.PLUS_SIGN))
        {
            address = address[1..];
        }
        if (address.Contains(Constants.Address.PLUS_SIGN))
        {
            var separatedAddressValue = address.Split(Constants.Address.PLUS_SIGN);
            if (FormatValidator.IsConstant(separatedAddressValue[1]))
            {
                (AddressStringValue, Offset) = (separatedAddressValue[0], AsmConverter.ToNumber(separatedAddressValue[1]));
                return true;
            }
            return false;
        }
        if (FormatValidator.IsConstant(address))
        {
            Offset = AsmConverter.ToNumber(address);
        }
        else
        {
            AddressStringValue = address;
        }
        return true;
    }

    /// <summary>
    /// Sets <see cref="Operand.Mod"/> and <see cref="Operand.RegisterOrMemory"/> based on <paramref name="firstPart"/>
    /// </summary>
    /// <param name="firstPart">Value of the register and mod.</param>
    private void HandleParts(string firstPart)
    {
        (Mod, RegisterOrMemory) = Constants.Address.ADRESS_TO_VALUES.ContainsKey(firstPart)
            ? Constants.Address.ADRESS_TO_VALUES[firstPart]
            : Dispose(firstPart)
                ? Constants.Address.DISPOSED_VALUES
                : (Mod, RegisterOrMemory);
    }

    /// <summary>
    /// Sets <see cref="Operand.Mod"/> and <see cref="Operand.RegisterOrMemory"/> based on <paramref name="firstPart"/> and <paramref name="secondPart"/>.
    /// </summary>
    /// <param name="firstPart">Value of the register and mod.</param>
    /// <param name="secondPart">Value of the register and mod.</param>
    private void HandleParts(string firstPart, string secondPart)
    {
        var parts = new[] { firstPart, secondPart };
        if (parts.ContainsAll(Constants.Register.BX, Constants.Register.SI))
            (Mod, RegisterOrMemory) = ("00", "000");
        if (parts.ContainsAll(Constants.Register.BX, Constants.Register.DI))
            (Mod, RegisterOrMemory) = ("00", "001");
        if (parts.ContainsAll(Constants.Register.BP, Constants.Register.SI))
            (Mod, RegisterOrMemory) = ("00", "010");
        if (parts.ContainsAll(Constants.Register.BP, Constants.Register.DI))
            (Mod, RegisterOrMemory) = ("00", "011");
        if (firstPart.Equals(Constants.Register.SI, StringComparison.InvariantCultureIgnoreCase) && Dispose(secondPart))
            RegisterOrMemory = "100";
        if (firstPart.Equals(Constants.Register.DI, StringComparison.InvariantCultureIgnoreCase) && Dispose(secondPart))
            RegisterOrMemory = "101";
        if (firstPart.Equals(Constants.Register.BP, StringComparison.InvariantCultureIgnoreCase) && Dispose(secondPart))
            RegisterOrMemory = "110";
        if (firstPart.Equals(Constants.Register.BX, StringComparison.InvariantCultureIgnoreCase) && Dispose(secondPart))
            RegisterOrMemory = "111";

    }

    /// <summary>
    /// Sets <see cref="Operand.Mod"/> and <see cref="Operand.RegisterOrMemory"/> based on <paramref name="firstPart"/>, <paramref name="secondPart"/>. and <paramref name="thirdPart"/>.
    /// </summary>
    /// <param name="firstPart">Value of the register and mod.</param>
    /// /// <param name="secondPart">Value of the register and mod.</param>
    /// /// <param name="thirdPart">Value of the register and mod.</param>
    private void HandleParts(string firstPart, string secondPart, string thirdPart)
    {
        var parts = new string[] { firstPart, secondPart, thirdPart };
        if (parts.ContainsAll(Constants.Register.BX, Constants.Register.SI) && Dispose(thirdPart))
            (Mod, RegisterOrMemory) = ("10", "000");
        if (parts.ContainsAll(Constants.Register.BX, Constants.Register.DI) && Dispose(thirdPart))
            (Mod, RegisterOrMemory) = ("10", "001");
        if (parts.ContainsAll(Constants.Register.BP, Constants.Register.SI) && Dispose(thirdPart))
            (Mod, RegisterOrMemory) = ("10", "010");
        if (parts.ContainsAll(Constants.Register.BP, Constants.Register.DI) && Dispose(thirdPart))
            (Mod, RegisterOrMemory) = ("10", "011");
    }

    /// <summary>
    /// Shuffle registers to the proper sequence.
    /// </summary>
    /// <param name="adressParts">Separated values of the address.</param>
    /// <returns>Reordered <paramref name="adressParts"/>.</returns>
    private static string[] HandleParts(string[] adressParts)
    {
        for (var i = 0; i < adressParts.Length; ++i)
        {
            if (FormatValidator.IsAddress(adressParts[i])) continue;
            (adressParts[i], adressParts[^1]) = (adressParts[^1], adressParts[i]);
            break;
        }
        return adressParts;
    }
}
