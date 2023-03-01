namespace FileDiagnosing.PropertyProviders;

/// <summary>
/// Classes that implement this interface will be collected with the reflection. <br/>
/// All properties will be automaticly displayed on the window.
/// </summary>
internal interface IFilePropertyProvider
{
    /// <summary>
    /// Title of the file property.
    /// </summary>
    string PropertyTitle { get; }

    /// <summary>
    /// Order of the displaying of the property.
    /// </summary>
    int DisplaingOrder { get; }

    /// <summary>
    /// Gets infromation about the file property with <paramref name="filePath"/>
    /// </summary>
    /// <param name="filePath">Absolute file path.</param>
    /// <returns>File property converted to string.</returns>
    string PropertyValue(string filePath);
}
