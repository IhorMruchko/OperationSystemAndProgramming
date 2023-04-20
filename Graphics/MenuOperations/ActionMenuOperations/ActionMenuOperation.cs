namespace Graphics.MenuOperations.ActionMenuOperations;

internal class ActionMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.ACTIONS;

    public override string InputGestureText => string.Empty;

    public override string IconFileSource => string.Empty;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.ACTIONS;

    public override List<MenuOperation> GroupOperations => new()
    {
        new RedoMenuItem(),
        new UndoMenuOperation(),
    };

    public override void HandleEvent(MainWindow source)
    {
        
    }

    public override bool IsKeyPressed(KeyEventArgs args)
    {
        return false;
    }
}
