using CombinatoricsCompiler.Compilation.States;
using System.Text;

namespace CombinatoricsCompiler.Compilation;

public class Compiler
{
    private StringBuilder _operator = new();
    private StringBuilder _number = new();

    private CompilationState _currentState;

    public Compiler()
    {
        _currentState = new InitialState(this);
    }

    public void Compile(string request)
    {
        for (var i = 0; i < request.Length; ++i)
        {
            _currentState.AcceptLetter(request[i]);
        }
    }

    internal void AddLetter(char letter)
    {
        _operator.Append(letter);
    }

    internal void AddNumber(char number)
    {
        _number.Append(number);
    }

    internal void ChangeState(CompilationState newState)
    {
        _currentState = newState;
    } 
}
