using CombinatoricsCompiler.Exceptions;

namespace CombinatoricsCompiler.Compilation.States;

public abstract class CompilationState
{
    protected Compiler Source { get; set; }

    protected List<(Predicate<char> validation, Action<char, Compiler> updater)> Transitions { get; set; }

    public CompilationState(Compiler source)
    {
        Source = source;
        source.ChangeState(this);
        Transitions = new()
        {
            Constants.Transitions.IsWhiteSpace,
        };
        InitTransitions();
    }
    public abstract string Evaluate();

    public void AcceptLetter(char v)
    {
        foreach(var (validation, updater) in Transitions)
        {
            if (validation(v) == true)
            {
                updater(v, Source);
                return;
            }
        }
        throw new UnexpectedSymbolException(v);
    }

    protected abstract void InitTransitions();
}
