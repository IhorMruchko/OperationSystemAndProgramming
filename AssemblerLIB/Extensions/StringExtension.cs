using static System.Math;

namespace TranslatorLIB.Extensions;

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
    public static string JoinString<T>(this string separator, IEnumerable<T> args)
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

    /// <summary>
    /// Creates <see cref="string"/> with <paramref name="value"/> repeated specified amount of <paramref name="times"/>.
    /// </summary>
    /// <param name="value">Value to repeat.</param>
    /// <param name="times">Times to repeat <paramref name="value"/>.</param>
    /// <returns><see cref="string"/> containing <paramref name="value"/> repeated specified amount of <paramref name="times"/></returns>
    public static string Repeat(this object value, int times)
        => string.Concat(Enumerable.Repeat(value, times));

    /// <summary>
    /// Inserts needed amount of times before <paramref name="value"/>.
    /// </summary>
    /// <param name="value"><see cref="string"/> to normalize in front.</param>
    /// <param name="filler">Value to insert in front of the <paramref name="value"/>.</param>
    /// <param name="amount">Expected length of the <paramref name="value"/> after normalizing.</param>
    /// <returns>Normalized <paramref name="value"/>.</returns>
    public static string NormalizeStart(this string value, object filler, int amount)
        => filler.Repeat(Abs(value.Length - amount)) + value;

    public static string ReplaceAll(this string source, string toReplace, string replaceWith)
    {
        while (source.Contains(toReplace))
        {
            source = source.Replace(toReplace, replaceWith);
        }
        return source;
    }
}
