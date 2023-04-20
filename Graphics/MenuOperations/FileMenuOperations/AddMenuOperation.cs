using Graphics.Commands;
using Graphics.Extensions;
using Microsoft.Win32;

namespace Graphics.MenuOperations.FileMenuOperations;

internal class AddMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.ADD;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.ADD;

    public override string IconFileSource => Constants.IO.Images.Icons.AddIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.ADD;

    public override List<MenuOperation> GroupOperations => new();

    public override void HandleEvent(MainWindow source)
    {
        if (source.OpennedFile is null != source.IsChangesMade)
        {
            new OpenMenuOperation().HandleEvent(source);
            return;
        }
        var openFileDialog = new OpenFileDialog()
        {
            InitialDirectory = Constants.IO.ResourcesDirectory,
            Filter = Constants.IO.Images.BMP_FILTER
        };
        if (openFileDialog.ShowDialog() == true)
        {
            source.PaintingCanvas.LoadImage(openFileDialog.FileName);
            source.Actions.Add(new AddPaintingAction(source, source.PaintingCanvas.Children[^1], 0, 0));
        }
    }

    public override bool IsKeyPressed(KeyEventArgs args)
        => Keyboard.IsKeyDown(Key.LeftCtrl)
        && Keyboard.IsKeyDown(Key.O);

}
