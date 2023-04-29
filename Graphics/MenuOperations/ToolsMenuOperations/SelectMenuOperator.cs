using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations;

internal class SelectMenuOperator : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.SELECT;

    public override List<MenuOperation> GroupOperations => new();

    public override Key[] KeyBind => new[] { Key.S };
    
    protected override string Name => Constants.MenuOperationsSettings.Names.SELECT;

    protected override string IconFileSource => Constants.IO.Images.Icons.SelectIcon;

    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new DrawSelectionTool();
    }
}
