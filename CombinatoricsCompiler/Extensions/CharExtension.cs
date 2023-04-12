namespace CombinatoricsCompiler.Extensions;

public static class CharExtension
{
    public static bool IsFactorial(this char value) 
        => value == Constants.FACTORIAL;

    public static bool IsPrimeFactorial(this char value)
        => value == Constants.PRIME_FACTORIAL;

    public static bool IsExponentialFactorial(this char value)
        => value == Constants.EXPONENTIAL_FACTORIAL;

    public static bool IsComma(this char value) 
        => value == Constants.COMMA;
}
