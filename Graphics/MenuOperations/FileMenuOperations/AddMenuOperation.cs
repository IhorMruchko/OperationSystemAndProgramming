using Graphics.Commands;
using Graphics.Extensions;
using Microsoft.Win32;

namespace Graphics.MenuOperations.FileMenuOperations;

internal class AddMenuOperation : MenuOperation
{
    protected override string Name => Constants.MenuOperationsSettings.Names.ADD;

    protected override string IconFileSource => Constants.IO.Images.Icons.AddIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.ADD;

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.O };

    protected override bool InsertSeparator => true;

    public override void HandleEvent(MainWindow source)
    {
        var openFileDialog = new OpenFileDialog()
        {
            InitialDirectory = Constants.IO.ResourcesDirectory,
            Filter = Constants.IO.Images.BMP_FILTER
        };
        if (openFileDialog.ShowDialog() == true)
        {
            source.PaintingCanvas.LoadImage(source, openFileDialog.FileName);
            source.ScrollBar.ScrollToTop();
            source.ScrollBar.ScrollToLeftEnd();
            source.Actions.Add(new AddPaintingAction(source, source.PaintingCanvas.Children[^1], 0, 0));
        }
    }
}
