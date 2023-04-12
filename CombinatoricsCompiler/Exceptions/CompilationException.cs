using System.Text;

namespace CombinatoricsCompiler.Exceptions;

internal class CompilationException : Exception
{
    public int Index { get; init; }

    public string TypeName { get; init; }

    public string CompilationLine { get; init; }

    public CompilationException(int index, string line, Exception innerException) 
        : base(innerException.Message)
        => (Index, CompilationLine, TypeName) = (index-1, line, innerException.GetType().Name);

    public override string ToString()
        => new StringBuilder(TypeName)
        .Append(':')
        .Append(' ')
        .AppendLine(Message)
        .AppendLine(CompilationLine)
        .Append(new string('-', Index))
        .Append('^')
        .ToString();
}
