using Graphics.Extensions;
using Graphics.Objects;
using System.Windows;

namespace Graphics.MenuOperations.FileMenuOperations;

internal class NewMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.NEW;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.NEW;

    public override string IconFileSource => Constants.IO.Images.Icons.NewFileIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.NEW;

    public override List<MenuOperation> GroupOperations => new();

    public override void HandleEvent(MainWindow source)
    {
        if (source.IsChangesMade && Messages.ChangesMadeMessage == MessageBoxResult.OK)
            new SaveMenuOperation().HandleEvent(source);

        source.PaintingCanvas.Clear();
        source.OpennedFile = null;
        source.IsChangesMade = false;
    }

    public override bool IsKeyPressed(KeyEventArgs args) 
        => Keyboard.IsKeyDown(Key.LeftCtrl) 
        && Keyboard.IsKeyDown(Key.N);
}
