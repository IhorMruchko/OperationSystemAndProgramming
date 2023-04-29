using System.Windows;
using Graphics.Extensions;

namespace Graphics.MenuOperations.EditMenuOperations;

internal class CopyMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.COPY;

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.C };

    protected override string Name => Constants.MenuOperationsSettings.Names.COPY;

    protected override string IconFileSource => Constants.IO.Images.Icons.CopyIcon;

    public override void HandleEvent(MainWindow source)
    {
        if (source.Selection is null) return;

        Clipboard.SetImage(source.PaintingCanvas.Crop(source.Selection, source.OperationsMenu.ActualHeight));
        
        source.Selection = null;
    }
}
