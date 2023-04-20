namespace Graphics.MenuOperations.EditMenuOperations;

internal class EditMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.EDIT;

    public override string InputGestureText => string.Empty;

    public override string IconFileSource => string.Empty;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.EDIT;

    public override List<MenuOperation> GroupOperations => new()
    {
        new CopyMenuOperation(),
        new PasteMenuOperation()
    };

    public override void HandleEvent(MainWindow source)
    {
        
    }

    public override bool IsKeyPressed(KeyEventArgs args)
    {
        return false;
    }
}
