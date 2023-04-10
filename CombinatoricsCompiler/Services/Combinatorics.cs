using System.Runtime.InteropServices;

namespace CombinatoricsCompiler.Services;

public static class Combinatorics
{
    [DllImport(Constants.DLL_SOURCE)]
    private static extern long P(long n);

    [DllImport(Constants.DLL_SOURCE)]
    private static extern long C(long n, long m);

    [DllImport(Constants.DLL_SOURCE)]
    private static extern long A(long n, long m);

    public static long Permutations(long n) 
        => P(n);

    public static long Combinations(long n, long m) 
        => C(n, m);

    public static long CombinationRepeating(long n, long m) 
        => A(n, m);
}
