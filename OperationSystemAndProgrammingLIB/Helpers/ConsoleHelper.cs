using System;
using System.Linq;

namespace OperationSystemAndProgrammingLIB.Helpers;

public static class ConsoleHelper
{
    private static readonly char[] _acceptableSeparators = new []
    {
        ' ', '\n', '\t'
    };

    public static string? ReadLine(object item, char separator=' ', bool shouldClear=true)
    {
        ValidateSeparator(separator);
        Console.Write($"{item}:{separator}");
        var input = Console.ReadLine();
        if (shouldClear) Console.Clear();
        return input;
    }

    private static void ValidateSeparator(char separator)
    {
        if (_acceptableSeparators.Contains(separator) == false)
            throw ExceptionHelper.NotInRangeException(nameof(separator), _acceptableSeparators);
    }
}
