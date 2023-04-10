namespace CombinatoricsCompiler.Compilation.States;

// TODO: provide proper states.
// TODO: add state of number appears.
// TODO: add state of letter appears.
// TODO: add state of sub factorial appears. 
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
            Constants.Transitions.IsNumber,
            Constants.Transitions.IsLetter
        };
        InitTransitions();
    }

    public bool AcceptLetter(char v)
    {
        foreach(var (validation, updater) in Transitions)
        {
            if (validation(v) == true)
            {
                updater(v, Source);
                return true;
            }
        }
        return false;
    }

    protected abstract void InitTransitions();
}
