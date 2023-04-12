using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations;

internal class DrawEllipseMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.ELLIPSE;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.ELLIPSE;

    public override string IconFileSource => Constants.IO.Images.Icons.ElipseIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.ELLIPSE;

    public override List<MenuOperation> GroupOperations => new();

    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new DrawElipseTool();
    }

    public override bool IsKeyPressed(KeyEventArgs args)
        => Keyboard.IsKeyDown(Key.LeftCtrl)
        && Keyboard.IsKeyDown(Key.LeftShift)
        && Keyboard.IsKeyDown(Key.E);

}
