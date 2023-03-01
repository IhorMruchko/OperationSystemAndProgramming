namespace FileDiagnosing.PropertyProviders;

/// <summary>
/// Class that represents file property value.
/// </summary>
internal class FileProperty
{
    /// <summary>
    /// Title of the file property.
    /// </summary>
    public string PropertyTitle { get; set; } = string.Empty;

    /// <summary>
    /// Evaluated value of the file property.
    /// </summary>
    public string PropertyValue { get; set; } = string.Empty;
}
