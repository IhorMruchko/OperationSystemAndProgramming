namespace Graphics.MenuOperations.FileMenuOperations;

internal class FileMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.FILE;

    public override List<MenuOperation> GroupOperations => new()
    {
        new NewMenuOperation(),
        new SaveMenuOperation(),
        new AddMenuOperation(),
        new ExitMenuOperation(),
    };

    protected override string Name => Constants.MenuOperationsSettings.Names.FILE;

    protected override string IconFileSource => string.Empty;
}
