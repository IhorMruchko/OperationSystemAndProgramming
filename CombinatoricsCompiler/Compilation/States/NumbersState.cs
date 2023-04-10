namespace CombinatoricsCompiler.Compilation.States;

internal class NumbersState : CompilationState
{
    public NumbersState(Compiler source) : base(source)
    {
    }

    // TODO: provide error on letter
    // TODO: if sign #, $, ! appears, change state to the needed factorial
    protected override void InitTransitions()
    {
        throw new NotImplementedException();
    }
}
