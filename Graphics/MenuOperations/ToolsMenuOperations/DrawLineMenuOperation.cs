using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations;

internal class DrawLineMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.LINE;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.LINE;

    public override string IconFileSource => Constants.IO.Images.Icons.LineIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.LINE;

    public override List<MenuOperation> GroupOperations => new();

    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new DrawLineTool();
    }

    public override bool IsKeyPressed(KeyEventArgs args)
        => Keyboard.IsKeyDown(Key.L);
}
