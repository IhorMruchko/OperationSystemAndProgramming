using Graphics.MenuOperations.ToolsMenuOperations.FilterToolsMenuOperations;

namespace Graphics.MenuOperations.ToolsMenuOperations;

internal class ToolsMenuOperation : MenuOperation
{
    protected override string Name => Constants.MenuOperationsSettings.Names.TOOLS;

    protected override string IconFileSource => string.Empty;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.TOOLS;

    public override List<MenuOperation> GroupOperations => new()
    {
        new DrawLineMenuOperation(),
        new MoveMenuOperation(),
        new DrawEllipseMenuOperation(),
        new DrawRectangleMenuOperation(),
        new SelectMenuOperator(),
        new RotateMenuOperation(),
        new FilterMenuOperation(),
    };
}
