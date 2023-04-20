using CombinatoricsCompiler.Compilation;
using CombinatoricsCompiler.Services;
using System.Text;

StringBuilder builder = new();

while (Inputs.Input(">>>") != "e")
{
    var compiler = new Compiler();
    if (Inputs.LastInput?.Equals("cls", StringComparison.InvariantCultureIgnoreCase) ?? false)
        Console.Clear();
    else
        LogResults(Inputs.LastInput, compiler.Compile(Inputs.LastInput));
}

File.WriteAllText("log.txt", builder.ToString());

void LogResults(string? userInput, string compilerResult)
{
    Console.WriteLine(compilerResult);
    
    builder.Append(">>>")
           .AppendLine(userInput)
           .AppendLine(compilerResult)
           .AppendLine(new string('-', 50));
}