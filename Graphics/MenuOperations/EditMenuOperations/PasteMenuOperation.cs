using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media; 
using System.Windows;
using Graphics.Commands;

namespace Graphics.MenuOperations.EditMenuOperations;

internal class PasteMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.PASTE;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.PASTE;

    public override string IconFileSource => Constants.IO.Images.Icons.PasteIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.PASTE;

    public override List<MenuOperation> GroupOperations => new();

    public override void HandleEvent(MainWindow source)
    {
        var image = Clipboard.GetImage();
        
        if (image is null) return;

        var img = new Image() { Source = image };
        source.PaintingCanvas.Children.Add(img);
        Canvas.SetTop(img, 0);
        Canvas.SetLeft(img, 0);
        source.Actions.Add(new AddPaintingAction(source, img, 0, 0));
    }

    public override bool IsKeyPressed(KeyEventArgs args)
        => Keyboard.IsKeyDown(Key.LeftCtrl)
        && Keyboard.IsKeyDown(Key.V);
}
