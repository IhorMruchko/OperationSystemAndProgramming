using System.IO;

namespace OperationSystemAndProgrammingLIB.Extensions;

/// <summary>
/// Extension class for the <see cref="string"/> objects.
/// </summary>
public static class StringExtension
{
    /// <summary>
    /// Simplifies <see cref="string"/> formatting.
    /// </summary>
    /// <param name="format">Format of the <see cref="string"/>.</param>
    /// <param name="args">Values to put in the format of the <see cref="string"/>.</param>
    /// <returns>Formatted <see cref="string"/>.</returns>
    public static string Format(this string format, params object[] args)
        => string.Format(format, args);

    /// <summary>
    /// Simplifies <see cref="string"/> joining.
    /// </summary>
    /// <param name="separator">Format of the <see cref="string"/>.</param>
    /// <param name="args">Values to join by <paramref name="separator"/> into <see cref="string"/>.</param>
    /// <returns>Joined <see cref="string"/>.</returns>
    public static string JoinString<T>(this string separator, T[] args)
        => string.Join(separator, args);

    /// <summary>
    /// Defines is <paramref name="filePath"/> is an existing file
    /// path of the extension equals to <paramref name="format"/>.
    /// </summary>
    /// <param name="filePath">Value of the path that is checked for extension.</param>
    /// <param name="format">Format of the file of the <paramref name="filePath"/> value.</param>
    /// <returns>
    /// <c>true</c> - if <paramref name="filePath"/> as file path exists and extension of the file equals to <paramref name="format"/>. <br/>
    /// <c>false</c> - otherwise.
    /// </returns>
    public static bool IsFilePathWithExtension(this string? filePath, string format)
        => File.Exists(filePath) && Path.GetExtension(filePath) == format;
}
