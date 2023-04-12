using CombinatoricsCompiler.Exceptions;
using CombinatoricsCompiler.Extensions;

namespace CombinatoricsCompiler.Compilation.States;

internal class LettersState : CompilationState
{
    public LettersState(Compiler source) : base(source)
    {
    }

    public override string Evaluate() 
        => throw new UnexpectedSymbolException('\0');

    // TODO: after accepting change to the proper function (Sf, H, P, A, C)
    // TODO: decline another values, except whitespace.
    protected override void InitTransitions()
    {
        Transitions.Adds(Constants.Transitions.IsLetter,
            (Constants.Transitions.Predicates.IsNumber, Constants.Transitions.Updates.ToOperatorState));
    }
}
