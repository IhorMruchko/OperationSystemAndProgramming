using Graphics.Extensions;
using Microsoft.Win32;

namespace Graphics.MenuOperations.FileMenuOperations;

internal class SaveMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.SAVE;

    public override List<MenuOperation> GroupOperations => new();
    
    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.S };

    protected override string Name => Constants.MenuOperationsSettings.Names.SAVE;

    protected override string IconFileSource => Constants.IO.Images.Icons.SaveIcon;

    public override void HandleEvent(MainWindow source)
    {
        var saveFileDialog = new SaveFileDialog()
        {
            InitialDirectory = Constants.IO.CurrentDirectory,
            Filter = Constants.IO.Images.BMP_FILTER,
        };

        if (saveFileDialog.ShowDialog() == true)
        {
            source.PaintingCanvas.Save(saveFileDialog.FileName);
            source.IsChangesMade = false;
        }
    }
}
