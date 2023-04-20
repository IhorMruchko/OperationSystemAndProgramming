using Graphics.Objects;
using System.Windows;

namespace Graphics.MenuOperations.FileMenuOperations;

internal class ExitMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.EXIT;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.EXIT;

    public override string IconFileSource => Constants.IO.Images.Icons.ExitIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.EXIT;

    public override List<MenuOperation> GroupOperations => new();

    public override void HandleEvent(MainWindow source)
    {
        if (source.IsChangesMade && Messages.ChangesMadeMessage == MessageBoxResult.Yes)
        {
            new SaveMenuOperation().HandleEvent(source);
            return;
        }

        if (Messages.LastResult == MessageBoxResult.Cancel)
        {
            return;
        }
    }

    public override bool IsKeyPressed(KeyEventArgs args)
        => Keyboard.IsKeyDown(Key.LeftCtrl)
        && Keyboard.IsKeyDown(Key.E);
}
