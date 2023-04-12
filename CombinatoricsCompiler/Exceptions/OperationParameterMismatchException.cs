namespace CombinatoricsCompiler.Exceptions;

internal class OperationParameterMismatchException : Exception
{
    private const string EXCEPTION_FORMAT = "Expected {0} parameters, instead {1}.";

    public OperationParameterMismatchException(int expected, int actual)
        : base(string.Format(EXCEPTION_FORMAT, expected, actual))
    {
    }
}
