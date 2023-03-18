using TranslatorLIB.Helpers;
using TranslatorLIB.Operands;

namespace TranslatorLIB.Operators;

public abstract class Operator
{
    internal int Lenght { get; set; }

    internal int Address { get; set; }

    internal bool HasAddress { get; set; }

    internal Operand? FirstOperand { get; set; }

    internal Operand? SecondOperand { get; set; }

    internal string CodeLine { get; set; } = string.Empty;

    public List<CommandFormat> Formats { get; set; } = new List<CommandFormat>();

    public Operator()
    {
        InitFormats();
    }

    public Operator(Operand first, Operand operand, int line)
    {

    }

    public virtual string Name => string.Empty;

    public virtual bool CanCreate(string possibleOperatorName)
        => possibleOperatorName.Equals(Name,
                                       StringComparison.InvariantCultureIgnoreCase);

    public abstract void InitFormats();
}
