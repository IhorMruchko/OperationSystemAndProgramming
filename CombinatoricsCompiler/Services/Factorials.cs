using System.Runtime.InteropServices;

namespace CombinatoricsCompiler.Services;

public static class Factorials
{
    [DllImport(Constants.DLL_SOURCE)]
    private static extern long factorial(long n);

    [DllImport(Constants.DLL_SOURCE)]
    private static extern long double_factorial(long n);

    [DllImport(Constants.DLL_SOURCE)]
    private static extern long subfactorial(long n);

    [DllImport(Constants.DLL_SOURCE)]
    private static extern long subfactorial_iterative(long n);

    [DllImport(Constants.DLL_SOURCE)]
    private static extern long prime_factorial(long n);

    [DllImport(Constants.DLL_SOURCE)]
    private static extern long superfactorial(long n);

    [DllImport(Constants.DLL_SOURCE)]
    private static extern long exponential_factorial(long n);

    [DllImport(Constants.DLL_SOURCE)]
    private static extern long hyper_factorial(long n);

    public static long Factorial(long n)
        => factorial(n);    

    public static long DoubleFactorial(long n)
        => double_factorial(n);

    public static long SubFactorial(long n)
        => subfactorial(n);

    public static long SubfactorialIterative(long n)
        => subfactorial_iterative(n);

    public static long PrimeFactorial(long n)
        => prime_factorial(n);

    public static long SuperFactorial(long n)
        => superfactorial(n);

    public static long ExponentialFactorial(long n)
        => exponential_factorial(n);

    public static long HyperFactorial(long n)
        => hyper_factorial(n);
}
