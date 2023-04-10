namespace CombinatoricsCompiler.Compilation.States;

public class InitialState : CompilationState
{
    public InitialState(Compiler source) : base(source)
    {
    }

    protected override void InitTransitions()
    {
        Transitions.AddRange(new (Predicate<char>, Action<char, Compiler>)[]
        {
            (c => c==Constants.FACTORIAL, (value, compiler) => {compiler.ChangeState(new FactorialState(Source)); } ),
        });
    }
}
