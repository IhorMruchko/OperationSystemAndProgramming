namespace CombinatoricsCompiler.Compilation.States
{
    internal class FactorialState : CompilationState
    {
        public FactorialState(Compiler source) : base(source)
        {
        }

        protected override void InitTransitions()
        {
            Transitions = new List<(Predicate<char> validation, Action<char, Compiler> updater)>()
            {
                Constants.Transitions.IsWhiteSpace,
            };
        }
    }
}