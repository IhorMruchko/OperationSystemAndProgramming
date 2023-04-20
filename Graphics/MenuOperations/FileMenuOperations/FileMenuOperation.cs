namespace Graphics.MenuOperations.FileMenuOperations;

internal class FileMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.FILE;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.FILE;

    public override string IconFileSource => string.Empty;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.FILE;

    // TODO: add Exit menu operation.
    // TODO: provide proper saving with same opened file directory.
    public override List<MenuOperation> GroupOperations => new()
    {
        new OpenMenuOperation(),
        new NewMenuOperation(),
        new SaveMenuOperation(),
        new AddMenuOperation(),
        new ExitMenuOperation(),
    };

    public override void HandleEvent(MainWindow source)
    {
    }

    public override bool IsKeyPressed(KeyEventArgs args)
    {
        return false;
    }
}
