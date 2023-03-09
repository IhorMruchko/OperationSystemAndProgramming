using OperationSystemAndProgrammingLIB.Extensions;
using System;

namespace OperationSystemAndProgrammingLIB.Helpers;

public static class ExceptionHelper
{
    public static ArgumentException NotInRangeException<T>(string parameterName, T[] range) 
        => new (Constants.Exceptions.ARGUMENT_NOT_IN_RANGE_EXCEPTION.Format(parameterName, ", ".JoinString(range)),
            parameterName);
}
