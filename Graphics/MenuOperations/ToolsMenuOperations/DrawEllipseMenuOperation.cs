using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations;

internal class DrawEllipseMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.ELLIPSE;

    public override List<MenuOperation> GroupOperations => new();

    public override Key[] KeyBind => new[] { Key.E };

    protected override string Name => Constants.MenuOperationsSettings.Names.ELLIPSE;

    protected override string IconFileSource => Constants.IO.Images.Icons.ElipseIcon;

    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new DrawElipseTool();
    }
}
