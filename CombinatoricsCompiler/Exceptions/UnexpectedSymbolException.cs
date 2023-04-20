namespace CombinatoricsCompiler.Exceptions;

internal class UnexpectedSymbolException : Exception
{
    private const string EXCEPTION_FORMAT = "[{0}] was not expected";
    public UnexpectedSymbolException(char letter) 
        : base(string.Format(EXCEPTION_FORMAT, letter)) { }
}
