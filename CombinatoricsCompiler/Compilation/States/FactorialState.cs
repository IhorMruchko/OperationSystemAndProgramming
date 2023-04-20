using CombinatoricsCompiler.Extensions;
using CombinatoricsCompiler.Services;

namespace CombinatoricsCompiler.Compilation.States
{
    internal class FactorialState : CompilationState
    {
        public FactorialState(Compiler source) : base(source)
        {
        }

        public override string Evaluate() 
            => Factorials.Factorial(long.Parse(Source.Number)).ToString();

        protected override void InitTransitions()
            => Transitions.Adds(Constants.Transitions.IsDoubleFactorial);
    }
}