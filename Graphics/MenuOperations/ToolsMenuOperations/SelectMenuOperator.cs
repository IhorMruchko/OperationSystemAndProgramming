using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations;

internal class SelectMenuOperator : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.SELECT;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.SELECT;

    public override string IconFileSource => Constants.IO.Images.Icons.SelectIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.SELECT;

    public override List<MenuOperation> GroupOperations => new();


    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new DrawSelectionTool();
    }

    public override bool IsKeyPressed(KeyEventArgs args)
        => Keyboard.IsKeyDown(Key.S);
}
