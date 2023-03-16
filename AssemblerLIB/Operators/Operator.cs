namespace TranslatorLIB.Operators;

public abstract class Operator
{
    internal int Lenght { get; set; }

    internal int Address { get; set; }

    internal bool HasAddress { get; set; }

    public virtual string Name => string.Empty;

    public virtual bool CanCreate(string possibleOperatorName)
        => possibleOperatorName.Equals(Name,
                                       StringComparison.InvariantCultureIgnoreCase);
}
