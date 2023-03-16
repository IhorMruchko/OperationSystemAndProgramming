using OperationSystemAndProgrammingLIB.Extensions;

namespace TranslatorLIB.Helpers;

public class CompileError : Exception
{
    public int LineNumber { get; private set; }

    public CompileError(string message, int lineNumber) : base(message)
    {
        LineNumber = lineNumber;
    }

    public static CompileError VariableNotFound(string variableName, int lineNumber = -1)
        => new(Constants.Errors.VARIABLE_NOT_FOUND.Format(variableName), lineNumber);

    public static CompileError WrongNumberFormat(string numberFormat)
        => new CompileError(Constants.Errors.WRONG_NUMERIC_INPUT.Format(numberFormat), -1);
}
