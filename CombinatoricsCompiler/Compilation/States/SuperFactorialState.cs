using CombinatoricsCompiler.Extensions;
using CombinatoricsCompiler.Services;

namespace CombinatoricsCompiler.Compilation.States;

internal class SuperFactorialState : CompilationState
{
    public SuperFactorialState(Compiler source) : base(source)
    {
    }

    public override string Evaluate() 
        => Factorials.SuperFactorial(long.Parse(Source.Number)).ToString();

    protected override void InitTransitions()
        => Transitions.Adds(Constants.Transitions.AddNumbers);
}
