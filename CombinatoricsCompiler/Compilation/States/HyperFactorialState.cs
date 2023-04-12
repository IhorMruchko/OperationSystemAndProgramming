using CombinatoricsCompiler.Extensions;
using CombinatoricsCompiler.Services;

namespace CombinatoricsCompiler.Compilation.States;

internal class HyperFactorialState : CompilationState
{
    public HyperFactorialState(Compiler source) : base(source)
    {
    }

    public override string Evaluate() 
        => Factorials.HyperFactorial(long.Parse(Source.Number)).ToString();

    protected override void InitTransitions() 
        => Transitions.Adds(Constants.Transitions.AddNumbers,
                            Constants.Transitions.EndOfParsing);
}
