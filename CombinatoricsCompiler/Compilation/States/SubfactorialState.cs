using CombinatoricsCompiler.Extensions;
using CombinatoricsCompiler.Services;

namespace CombinatoricsCompiler.Compilation.States
{
    internal class SubfactorialState : CompilationState
    {
        public SubfactorialState(Compiler source) : base(source)
        {
        }

        public override string Evaluate()
        {
            return Factorials.SubfactorialIterative(long.Parse(Source.Number)).ToString();
        }

        protected override void InitTransitions()
        {
            Transitions.Adds((Constants.Transitions.Predicates.IsNumber, Constants.Transitions.Updates.AddNumber),
                             Constants.Transitions.EndOfParsing);
        }
    }
}