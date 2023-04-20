using Graphics.Extensions;
using Graphics.Objects;
using Microsoft.Win32;
using System.Windows;

namespace Graphics.MenuOperations.FileMenuOperations;

internal class OpenMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.OPEN;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.OPEN;

    public override string IconFileSource => Constants.IO.Images.Icons.OpenIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.OPEN;

    public override List<MenuOperation> GroupOperations => new();

    public override void HandleEvent(MainWindow source)
    {
        if (source.IsChangesMade && Messages.ChangesMadeMessage == MessageBoxResult.Yes)
            new SaveMenuOperation().HandleEvent(source);

        if (Messages.LastResult == MessageBoxResult.Cancel)
            return;

        var openFileDialog = new OpenFileDialog()
        {
            InitialDirectory = Constants.IO.ResourcesDirectory,
            Filter = Constants.IO.Images.BMP_FILTER
        };
        if (openFileDialog.ShowDialog() == true)
        {
            source.PaintingCanvas.Clear();
            source.PaintingCanvas.LoadImage(openFileDialog.FileName);
            source.OpennedFile = openFileDialog.FileName;
            source.IsChangesMade = false;
        }
    }

    public override bool IsKeyPressed(KeyEventArgs args) 
        => Keyboard.IsKeyDown(Key.O)
        && Keyboard.IsKeyDown(Key.LeftCtrl)
        && Keyboard.IsKeyDown(Key.LeftShift);
}
