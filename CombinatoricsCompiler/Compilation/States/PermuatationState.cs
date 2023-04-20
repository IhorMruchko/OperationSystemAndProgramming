using CombinatoricsCompiler.Extensions;
using CombinatoricsCompiler.Services;

namespace CombinatoricsCompiler.Compilation.States;

internal class PermuatationState : CompilationState
{
    public PermuatationState(Compiler source) : base(source)
    {
    }

    public override string Evaluate()
        => Combinatorics.Permutations(long.Parse(Source.Number)).ToString();

    protected override void InitTransitions()
        => Transitions.Adds(Constants.Transitions.AddNumbers, Constants.Transitions.EndOfParsing);
}
