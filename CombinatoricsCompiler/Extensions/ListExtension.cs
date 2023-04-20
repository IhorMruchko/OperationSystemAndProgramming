namespace CombinatoricsCompiler.Extensions;

public static class ListExtension
{
    public static List<T> Adds<T>(this List<T> source, params T[] objects)
    {
        source.AddRange(objects);
        return source;
    }
}
