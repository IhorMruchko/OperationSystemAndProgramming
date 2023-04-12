using Graphics.MenuOperations;
using System.Linq;

namespace Graphics.Extensions;

public static class ListExtension
{
    public static List<MenuOperation> GetOperations(this List<MenuOperation> source)
    {
        return source.Concat(source.SelectMany(s => s.GroupOperations.GetOperations())).ToList();
    }
}
