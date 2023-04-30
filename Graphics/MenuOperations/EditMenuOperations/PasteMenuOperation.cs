using System.Windows.Controls;
using System.Windows;
using Graphics.Commands;

namespace Graphics.MenuOperations.EditMenuOperations;

internal class PasteMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.PASTE;

    public override List<MenuOperation> GroupOperations => new();

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.V };

    protected override string Name => Constants.MenuOperationsSettings.Names.PASTE;

    protected override string IconFileSource => Constants.IO.Images.Icons.PasteIcon;

    public override void HandleEvent(MainWindow source)
    {
        var image = Clipboard.GetImage();
        
        if (image is null) return;

        var img = new Image() { Source = image };
        img.Loaded += (_, _) => source.UpdateScrollBar();
        source.PaintingCanvas.Children.Add(img);
        
        Canvas.SetTop(img, source.ScrollBar.VerticalOffset);
        Canvas.SetLeft(img, source.ScrollBar.HorizontalOffset);
        source.Actions.Add(new AddPaintingAction(source,
                                                 img,
                                                 source.ScrollBar.VerticalOffset,
                                                 source.ScrollBar.HorizontalOffset));
    }
}
