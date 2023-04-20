using TranslatorLIB.Extensions;

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
        => new(Constants.Errors.WRONG_NUMERIC_INPUT.Format(numberFormat), -1);

    public static CompileError RegisterNotFound(string registerValue)
        => new(Constants.Errors.REGISTER_NOT_FOUND.Format(registerValue), -1);

    public static CompileError SegmentRegisterNotFound(string segmentRegisterValue)
        => new(Constants.Errors.SEGMENT_REGISTER_NOT_FOUND.Format(segmentRegisterValue), -1);
}
