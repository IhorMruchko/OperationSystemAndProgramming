namespace Graphics.MenuOperations.ActionMenuOperations;

internal class RedoMenuItem : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.REDO;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.REDO;

    public override string IconFileSource => Constants.IO.Images.Icons.RedoIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.REDO;

    public override List<MenuOperation> GroupOperations => new();

    public override void HandleEvent(MainWindow source)
    {
        source.Actions.Redo();
    }

    public override bool IsKeyPressed(KeyEventArgs args)
        => Keyboard.IsKeyDown(Key.LeftCtrl)
        && Keyboard.IsKeyDown(Key.Y);
}
