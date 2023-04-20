using CombinatoricsCompiler.Extensions;
using CombinatoricsCompiler.Services;

namespace CombinatoricsCompiler.Compilation.States;

internal class PrimeFactorialState : CompilationState
{
    public PrimeFactorialState(Compiler source) : base(source)
    {
    }

    public override string Evaluate() 
        => Factorials.PrimeFactorial(long.Parse(Source.Number)).ToString();

    protected override void InitTransitions() 
        => Transitions.Adds(Constants.Transitions.EndOfParsing);
}
