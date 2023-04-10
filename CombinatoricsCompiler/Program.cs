using CombinatoricsCompiler.Services;

while (Inputs.Input(">>>") != "e")
{
    if (int.TryParse(Inputs.LastInput, out var result))
    {
        Console.WriteLine(Combinatorics.Permutations(result));
    }
}