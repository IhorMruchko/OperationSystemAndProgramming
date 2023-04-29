namespace Graphics.MenuOperations.ActionMenuOperations;

internal class UndoMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.UNDO;

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.Z };

    protected override string Name => Constants.MenuOperationsSettings.Names.UNDO;

    protected override string IconFileSource => Constants.IO.Images.Icons.UndoIcon;

    public override void HandleEvent(MainWindow source)
    {
        source.Actions.Undo();
    }
}
