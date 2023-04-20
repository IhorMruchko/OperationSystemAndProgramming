using CombinatoricsCompiler.Exceptions;
using CombinatoricsCompiler.Extensions;
using CombinatoricsCompiler.Services;

namespace CombinatoricsCompiler.Compilation.States;

internal class CombinationState : CompilationState
{
    public CombinationState(Compiler source) : base(source)
    {
    }

    public override string Evaluate()
    {
        var number = Source.Number.Split(Constants.COMMA);
        if (number.Length != 2)
            throw new OperationParameterMismatchException(2, number.Length);

        if (long.TryParse(number[0], out var n) == false)
            throw new ArgumentException($"C operator expects long value, instead {number[0]}");

        if (long.TryParse(number[1], out var m) == false)
            throw new ArgumentException($"C operator expects long value, instead {number[1]}");

        if (n < m)
            (n, m) = (m, n);

        return Combinatorics.Combinations(n, m).ToString();
    }

    protected override void InitTransitions()
    {
        Transitions.Adds(Constants.Transitions.AddNumbers,
                         Constants.Transitions.AddComma,
                         Constants.Transitions.EndOfParsing);
    }
}
