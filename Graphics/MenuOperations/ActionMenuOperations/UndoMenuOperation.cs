namespace Graphics.MenuOperations.ActionMenuOperations;

internal class UndoMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.UNDO;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.UNDO;

    public override string IconFileSource => Constants.IO.Images.Icons.UndoIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.UNDO;

    public override List<MenuOperation> GroupOperations => new();

    public override void HandleEvent(MainWindow source)
    {
        source.Actions.Undo();
    }

    public override bool IsKeyPressed(KeyEventArgs args)
        => Keyboard.IsKeyDown(Key.LeftCtrl)
        && Keyboard.IsKeyDown(Key.Z);
}
