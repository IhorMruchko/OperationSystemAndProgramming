using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations;

internal class DrawLineMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.LINE;

    public override List<MenuOperation> GroupOperations => new();

    public override Key[] KeyBind => new[] { Key.L };

    protected override string Name => Constants.MenuOperationsSettings.Names.LINE;

    protected override string IconFileSource => Constants.IO.Images.Icons.LineIcon;

    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new DrawLineTool();
    }
}
