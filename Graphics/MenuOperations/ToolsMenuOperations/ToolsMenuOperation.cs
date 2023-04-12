namespace Graphics.MenuOperations.ToolsMenuOperations;

internal class ToolsMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.TOOLS;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.TOOLS;

    public override string IconFileSource => string.Empty;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.TOOLS;

    // TODO: add path drawing
    public override List<MenuOperation> GroupOperations => new()
    {
        new DrawLineMenuOperation(),
        new MoveMenuOperation(),
        new DrawEllipseMenuOperation(),
        new DrawRectangleMenuOperation(),
    };

    public override void HandleEvent(MainWindow source)
    {
    }

    public override bool IsKeyPressed(KeyEventArgs args)
    {
        return false;
    }
}
