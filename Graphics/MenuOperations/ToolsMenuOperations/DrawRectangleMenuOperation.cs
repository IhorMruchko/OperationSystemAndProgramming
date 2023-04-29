using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations;

internal class DrawRectangleMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.RECTANGLE;

    public override Key[] KeyBind => new[] { Key.R };

    protected override string Name => Constants.MenuOperationsSettings.Names.RECTANGLE;

    protected override string IconFileSource => Constants.IO.Images.Icons.RectangleIcon;

    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new DrawRectangleTool();
    }
}
