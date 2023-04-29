namespace Graphics.MenuOperations.ActionMenuOperations;

internal class ActionMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.ACTIONS;

    public override List<MenuOperation> GroupOperations => new()
    {
        new RedoMenuItem(),
        new UndoMenuOperation(),
    };

    protected override string Name => Constants.MenuOperationsSettings.Names.ACTIONS;

    protected override string IconFileSource => string.Empty;
}
