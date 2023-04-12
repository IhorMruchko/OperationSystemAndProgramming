using CombinatoricsCompiler.Extensions;

namespace CombinatoricsCompiler.Compilation.States;

public class InitialState : CompilationState
{
    public InitialState(Compiler source) : base(source)
    {
    }

    public override string Evaluate() 
        => string.Empty;

    protected override void InitTransitions()
        => Transitions.Adds(Constants.Transitions.IsLetter,
                            Constants.Transitions.IsNumber,
                            Constants.Transitions.IsSubFactorial);
}
