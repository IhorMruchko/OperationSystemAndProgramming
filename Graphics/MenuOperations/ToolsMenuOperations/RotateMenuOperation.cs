using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations;

internal class RotateMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.ROTATE;

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.R };

    protected override string Name => Constants.MenuOperationsSettings.Names.ROTATE;

    protected override string IconFileSource => Constants.IO.Images.Icons.RotateIcon;

    protected override bool InsertSeparator => true;

    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new RotateTool();
    }
}
