using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations;

internal class DrawRectangleMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.RECTANGLE;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.RECTANGLE;

    public override string IconFileSource => Constants.IO.Images.Icons.RectangleIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.RECTANGLE;

    public override List<MenuOperation> GroupOperations => new ();

    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new DrawRectangleTool();
    }

    public override bool IsKeyPressed(KeyEventArgs args)
        => Keyboard.IsKeyDown(Key.R);
}
