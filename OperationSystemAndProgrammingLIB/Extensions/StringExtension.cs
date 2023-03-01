using System.Collections.Generic;

namespace OperationSystemAndProgrammingLIB.Extensions;

/// <summary>
/// Exntension class for the <see cref="string"/> objects.
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
    public static string Join(this string separator, IEnumerable<object> args) 
        => string.Join(separator, args);
}
