using CombinatoricsCompiler.Compilation;
using CombinatoricsCompiler.Compilation.States;
using CombinatoricsCompiler.Extensions;

namespace CombinatoricsCompiler;


public static class Constants
{
    public const string DLL_SOURCE = "DLL\\OperationSystemAndProgramming.Combinatorics.dll";

    public const char FACTORIAL = '!';

    public static class Transitions
    {
        public static class Predicates
        {
            public static readonly Predicate<char> IsWhiteSpace = c => char.IsWhiteSpace(c);
            public static readonly Predicate<char> IsNumber = c => char.IsNumber(c);
            public static readonly Predicate<char> IsLetter = c => char.IsLetter(c);
            public static readonly Predicate<char> IsFactorial = c => c.IsFactorial();
        }

        public static class Updates
        {
            public static readonly Action<char, Compiler> IsWhiteSpace = (_, _) => { };
            public static readonly Action<char, Compiler> IsNumber = (value, compiler) => 
            {
                compiler.AddNumber(value);
                compiler.ChangeState(new NumbersState(compiler));
            };
            public static readonly Action<char, Compiler> IsLetter = (value, compiler) =>
            {
                compiler.AddLetter(value);
                compiler.ChangeState(new LettersState(compiler));
            };
        }
        
        public static readonly (Predicate<char>, Action<char, Compiler>) IsWhiteSpace
            = (Predicates.IsWhiteSpace, Updates.IsWhiteSpace);

        public static readonly (Predicate<char>, Action<char, Compiler>) IsNumber =
            (Predicates.IsNumber, Updates.IsNumber);

        public static readonly (Predicate<char>, Action<char, Compiler>) IsLetter =
            (Predicates.IsLetter, Updates.IsLetter);
    }
}
