using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations;

internal class MoveMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.MOVER;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.MOVER;

    public override string IconFileSource => Constants.IO.Images.Icons.MoveIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.MOVER;

    public override List<MenuOperation> GroupOperations => new();

    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new MoveTool();
    }

    public override bool IsKeyPressed(KeyEventArgs args)
        => Keyboard.IsKeyDown(Key.M);
}