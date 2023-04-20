using System.Runtime.InteropServices;

internal class Program
{
    [DllImport("OperationSystemAndProgramming.WinLib.dll")]
    public static extern bool all_smaller_than(int[] source, int upperBound, int size);

    [DllImport("OperationSystemAndProgramming.WinLib.dll")]
    public static extern int from_roman(string roman, int size);
    
    private static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var romans = new List<int>();
        while(input != "e" || input is not null)
        {
            if (int.TryParse(input, out var val))
            {
                Console.WriteLine(string.Join(", ", romans));
                Console.WriteLine(all_smaller_than(romans.ToArray(), val, romans.Count));
                input = Console.ReadLine();
                continue;
            }

            if (input == "cls")
            {
                Console.Clear();
                romans.Clear();
                input = Console.ReadLine();
                continue;
            }

            if (input == "exit")
            {
                break;
            }

            var value = from_roman(input, input.Length);
            Console.WriteLine($"{input} - {value}");
            romans.Add(value);
            input = Console.ReadLine();
        }
    }
}