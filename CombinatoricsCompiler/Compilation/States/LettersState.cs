namespace CombinatoricsCompiler.Compilation.States;

internal class LettersState : CompilationState
{
    public LettersState(Compiler source) : base(source)
    {
    }

    // TODO: accept only '(',
    // TODO: after accepting change to the proper function (Sf, H, P, A, C)
    // TODO: decline another values, except whitespace.
    protected override void InitTransitions()
    {
        throw new NotImplementedException();
    }
}
