namespace Graphics.MenuOperations.ActionMenuOperations;

internal class RedoMenuItem : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.REDO;

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.Y };

    protected override string Name => Constants.MenuOperationsSettings.Names.REDO;

    protected override string IconFileSource => Constants.IO.Images.Icons.RedoIcon;

    public override void HandleEvent(MainWindow source)
    {
        source.Actions.Redo();
    }
}
