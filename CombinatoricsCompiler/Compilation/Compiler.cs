using CombinatoricsCompiler.Compilation.States;
using CombinatoricsCompiler.Exceptions;
using System.Text;

namespace CombinatoricsCompiler.Compilation;

public class Compiler
{
    private readonly StringBuilder _operator = new();
    private readonly StringBuilder _number = new();

    private CompilationState _currentState;

    public string Number
    {
        get
        {
            var value = _number.ToString();
            _number.Clear();
            return value;
        }
    }

    public string Operation
    {
        get
        {
            var value = _operator.ToString();
            _operator.Clear();
            return value.ToLower();
        }
    }

    public Compiler()
    {
        _currentState = new InitialState(this);
    }

    public string Compile(string? request)
    {
        if (request is null)
            return string.Empty;
        try
        {
            return ParseRequest(request);
        }
        catch (CompilationException e)
        {
            return e.ToString();
        }
    }

    private string ParseRequest(string request)
    {
        var index = 0;
        try
        {
            while (index < request.Length)
                _currentState.AcceptLetter(request[index++]);

            return _currentState.Evaluate();
        }
        catch(Exception e) 
        {
            throw new CompilationException(index, request, e);
        }
    }

    internal void AddLetter(char letter)
        => _operator.Append(letter);

    internal void AddNumber(char number) 
        => _number.Append(number);

    internal void ChangeState(CompilationState newState) 
        => _currentState = newState;
}
