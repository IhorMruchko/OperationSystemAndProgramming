using CombinatoricsCompiler.Compilation;
using CombinatoricsCompiler.Compilation.States;
using CombinatoricsCompiler.Exceptions;
using CombinatoricsCompiler.Extensions;

namespace CombinatoricsCompiler;


public static class Constants
{
    public const string DLL_SOURCE = "DLL\\OperationSystemAndProgramming.Combinatorics.dll";

    public const char FACTORIAL = '!';
    public const char PRIME_FACTORIAL = '#';
    public const char EXPONENTIAL_FACTORIAL = '$';
    public const char COMMA = ',';

    public static class Transitions
    {
        public static class Commands
        {
            public static readonly Dictionary<string, Func<Compiler, CompilationState>> PossibleCommands = new()
            {
                ["sf"] = compiler => new SuperFactorialState(compiler),
                ["h"] = compiler => new HyperFactorialState(compiler),
                ["p"] = compiler => new PermuatationState(compiler),
                ["c"] = compiler => new CombinationState(compiler),
                ["a"] = compiler => new AOperatorState(compiler)
            };

            public static CompilationState GetState(Compiler compiler)
            {
                var operationName = compiler.Operation;
                if (PossibleCommands.ContainsKey(operationName) == false)
                    throw new OperatorIsNotSuportedException(operationName);

                return PossibleCommands[operationName](compiler);
            }
        }
        public static class Predicates
        {
            public static readonly Predicate<char> AnyLetter = _ => true;
            public static readonly Predicate<char> IsWhiteSpace = c => char.IsWhiteSpace(c);
            public static readonly Predicate<char> IsNumber = c => char.IsNumber(c);
            public static readonly Predicate<char> IsLetter = c => char.IsLetter(c);
            public static readonly Predicate<char> IsFactorial = c => c.IsFactorial();
            public static readonly Predicate<char> IsPrimeFactorial = c => c.IsPrimeFactorial();
            public static readonly Predicate<char> IsExponentialFactorial = c => c.IsExponentialFactorial();
            public static readonly Predicate<char> IsComma = c => c.IsComma();
        }

        public static class Updates
        {
            public static readonly Action<char, Compiler> IsWhiteSpace = (_, _) => { };
            
            public static readonly Action<char, Compiler> AddNumber = (value, compiler) 
                => compiler.AddNumber(value);
            
            public static readonly Action<char, Compiler> ToNumberState = (value, compiler) => 
            {
                compiler.AddNumber(value);
                compiler.ChangeState(new NumbersState(compiler));
            };
            
            public static readonly Action<char, Compiler> ToLetterState = (value, compiler) =>
            {
                compiler.AddLetter(value);
                compiler.ChangeState(new LettersState(compiler));
            };

            public static readonly Action<char, Compiler> FactorialState = (value, compiler) =>
                compiler.ChangeState(new FactorialState(compiler));

            public static readonly Action<char, Compiler> DoubleFactorialState = (_, compiler) =>
                compiler.ChangeState(new DoubleFactorialState(compiler));

            public static readonly Action<char, Compiler> SubFactorialState = (_, compiler) =>
                compiler.ChangeState(new SubfactorialState(compiler));

            public static readonly Action<char, Compiler> UnexpectedSymbol = (value, compiler)
                => throw new UnexpectedSymbolException(value);
            
            public static readonly Action<char, Compiler> PrimeFactorial = (_, compiler) 
                => compiler.ChangeState(new PrimeFactorialState(compiler));
            
            public static readonly Action<char, Compiler> ExponentialFactorial = (_, compiler) 
                => compiler.ChangeState(new ExponentialFactorialState(compiler));
            
            public static readonly Action<char, Compiler> ToOperatorState = (number, compiler) =>
            {
                compiler.ChangeState(Commands.GetState(compiler));
                compiler.AddNumber(number);
            };
        }
        
        public static readonly (Predicate<char>, Action<char, Compiler>) IsWhiteSpace
            = (Predicates.IsWhiteSpace, Updates.IsWhiteSpace);

        public static readonly (Predicate<char>, Action<char, Compiler>) IsNumber =
            (Predicates.IsNumber, Updates.ToNumberState);

        public static readonly (Predicate<char>, Action<char, Compiler>) IsLetter =
            (Predicates.IsLetter, Updates.ToLetterState);

        public static readonly (Predicate<char>, Action<char, Compiler>) IsFactorial =
            (Predicates.IsFactorial, Updates.FactorialState);

        public static readonly (Predicate<char>, Action<char, Compiler>) IsDoubleFactorial =
            (Predicates.IsFactorial, Updates.DoubleFactorialState);

        public static readonly (Predicate<char>, Action<char, Compiler>) IsSubFactorial =
            (Predicates.IsFactorial, Updates.SubFactorialState);

        public static readonly (Predicate<char>, Action<char, Compiler>) IsPrimeFactorial =
            (Predicates.IsPrimeFactorial, Updates.PrimeFactorial);
        
        public static readonly (Predicate<char>, Action<char, Compiler>) IsExponentialFactorial =
            (Predicates.IsExponentialFactorial, Updates.ExponentialFactorial);
        
        public static readonly (Predicate<char>, Action<char, Compiler>) EndOfParsing =
            (Predicates.AnyLetter, Updates.UnexpectedSymbol);

        public static readonly (Predicate<char>, Action<char, Compiler>) AddNumbers =
            (Predicates.IsNumber, Updates.AddNumber);

        public static readonly (Predicate<char>, Action<char, Compiler>) AddComma =
            (Predicates.IsComma, Updates.AddNumber);
    }
}
