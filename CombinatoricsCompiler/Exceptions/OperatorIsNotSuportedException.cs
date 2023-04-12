namespace CombinatoricsCompiler.Exceptions;

internal class OperatorIsNotSuportedException : Exception
{
    private const string ERROR_FORMAT = "Unknown operator `{0}`.";
    
    public OperatorIsNotSuportedException(string operatorName) 
        :base(string.Format(ERROR_FORMAT, operatorName))
    {
    }
}
