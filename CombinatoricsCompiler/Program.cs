using CombinatoricsCompiler.Compilation;
using CombinatoricsCompiler.Services;

while (Inputs.Input(">>>") != "e")
{
    var compiler = new Compiler();
    if (Inputs.LastInput?.Equals("cls", StringComparison.InvariantCultureIgnoreCase) ?? false)
        Console.Clear();
    else
        Console.WriteLine(compiler.Compile(Inputs.LastInput));
}