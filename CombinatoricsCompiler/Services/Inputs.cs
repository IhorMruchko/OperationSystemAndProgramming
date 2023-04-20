namespace CombinatoricsCompiler.Services;

public static class Inputs
{
    public static string? LastInput { get; private set; } = null;
    
    public static string? Input(string? message = null, string ending = " ")
    {
        if (message is not null)
        {
            Console.Write(message + ending);
        }
        
        LastInput = Console.ReadLine();
        return LastInput;
    }
}
