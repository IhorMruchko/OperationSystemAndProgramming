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
    /// <returns></returns>
    public static string Format(this string format, params object[] args) 
        => string.Format(format, args);
}
