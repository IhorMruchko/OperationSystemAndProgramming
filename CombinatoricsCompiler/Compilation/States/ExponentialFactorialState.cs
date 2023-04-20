using CombinatoricsCompiler.Extensions;
using CombinatoricsCompiler.Services;

namespace CombinatoricsCompiler.Compilation.States;

internal class ExponentialFactorialState : CompilationState
{
    public ExponentialFactorialState(Compiler source) : base(source)
    {
    }

    public override string Evaluate() 
        => Factorials.ExponentialFactorial(long.Parse(Source.Number)).ToString();

    protected override void InitTransitions() 
        => Transitions.Adds(Constants.Transitions.EndOfParsing);
}
