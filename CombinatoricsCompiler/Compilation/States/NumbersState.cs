using CombinatoricsCompiler.Extensions;

namespace CombinatoricsCompiler.Compilation.States;

internal class NumbersState : CompilationState
{
    public NumbersState(Compiler source) : base(source)
    {
    }

    public override string Evaluate() 
        => Source.Number;

    protected override void InitTransitions() 
        => Transitions.Adds(Constants.Transitions.AddNumbers,
                            Constants.Transitions.IsFactorial,
                            Constants.Transitions.IsPrimeFactorial,
                            Constants.Transitions.IsExponentialFactorial,
                            Constants.Transitions.EndOfParsing);
}
