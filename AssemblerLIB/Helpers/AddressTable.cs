namespace TranslatorLIB.Helpers;

/// <summary>
/// Represents address table of the assembler's translator.
/// </summary>
public class AddressTable
{
    /// <summary>
    /// Address table source;
    /// </summary>
    public Dictionary<string, string> StoredAdresses { get; private set; } = new();

    /// <summary>
    /// Adds new address to the table and set is with default value.
    /// </summary>
    /// <remarks>
    /// If item is already set - do nothing.
    /// </remarks>
    /// <param name="address">New address in the table.</param>
    public void Add(string address)
    {
        address = address.ToUpper();

        if (string.IsNullOrEmpty(address) || StoredAdresses.ContainsKey(address))
            return;

        StoredAdresses[address] = string.Empty;
    }

    /// <summary>
    /// Sets value in the address.
    /// </summary>
    /// <param name="address">Address where value will be set.</param>
    /// <param name="adressValue">Value to set in the address table.</param>
    /// <exception cref="CompileError"> <paramref name="address"/> in the table is not found.</exception>
    public void Set(string address, int adressValue)
    {
        address = address.ToUpper();

        if (StoredAdresses.ContainsKey(address) == false)
            throw CompileError.VariableNotFound(address);

        StoredAdresses[address] = adressValue.ToString();
    }

    /// <summary>
    /// Gets value from the address.
    /// </summary>
    /// <param name="address">Address where value is set.</param>
    /// <param name="offset">Offset of the value that gets from the table.</param>
    /// <param name="bytes">Number of bytes used to store value.</param>
    /// <exception cref="CompileError"> <paramref name="address"/> in the table is not found.</exception>
    /// <returns><see cref="string"/> value stored in the <paramref name="address"/> with proper conversion.</returns>
    public string Get(string address, int offset, int bytes)
    {
        if (StoredAdresses.ContainsKey(address) == false)
            throw CompileError.VariableNotFound(address);

        var valueInAddress = StoredAdresses[address];

        return AsmConverter.DecimalToBase(AsmConverter.ToPositive(AsmConverter.ToNumber(valueInAddress) + offset,
                                                                  bytes),
                                          Constants.Converting.BINARY_BASE);
    }
}
