namespace TranslatorLIB.Extensions;

public static class EnumerableExtension
{
    /// <summary>
    /// Checks weather all elements in <paramref name="values"/> are in <paramref name="source"/>.
    /// </summary>
    /// <typeparam name="T">Any object type to compare.</typeparam>
    /// <param name="source">Container with the values needed.</param>
    /// <param name="values">Values to check is containing in <paramref name="source"/>.</param>
    /// <returns>
    /// <c>true</c> - if all elements in <paramref name="values"/> are in <paramref name="source"/>. <br/>
    /// <c>false</c> - otherwise.
    /// </returns>
    public static bool ContainsAll<T>(this IEnumerable<T> source, params T[] values)
        => values.All(value => source.Contains(value));
}
