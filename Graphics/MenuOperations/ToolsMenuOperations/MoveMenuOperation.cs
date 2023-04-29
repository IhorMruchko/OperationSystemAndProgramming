using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations;

internal class MoveMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.MOVER;

    public override Key[] KeyBind => new[] { Key.M };

    public override List<MenuOperation> GroupOperations => new();

    protected override string Name => Constants.MenuOperationsSettings.Names.MOVER;

    protected override string IconFileSource => Constants.IO.Images.Icons.MoveIcon;


    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new MoveTool();
    }
}