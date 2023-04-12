using CombinatoricsCompiler.Extensions;
using CombinatoricsCompiler.Services;

namespace CombinatoricsCompiler.Compilation.States;

internal class DoubleFactorialState : CompilationState
{
    public DoubleFactorialState(Compiler source) : base(source)
    {
    }

    public override string Evaluate() 
        => Factorials.DoubleFactorial(long.Parse(Source.Number)).ToString();

    protected override void InitTransitions() 
        => Transitions.Adds(Constants.Transitions.EndOfParsing);
}
