using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace Graphics.MenuOperations.EditMenuOperations;

internal class CopyMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.COPY;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.COPY;

    public override string IconFileSource => Constants.IO.Images.Icons.CopyIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.COPY;

    public override List<MenuOperation> GroupOperations => new();

    public override void HandleEvent(MainWindow source)
    {
        if (source.Selection is null) return;
        var render = new RenderTargetBitmap((int)source.PaintingCanvas.ActualWidth, (int)source.PaintingCanvas.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);
        source.PaintingCanvas.Children.Remove(source.Selection);
        render.Render(source.PaintingCanvas);
        var cropped = new CroppedBitmap(render, new Int32Rect((int)Canvas.GetLeft(source.Selection), (int)Canvas.GetTop(source.Selection) + 20, (int)source.Selection.ActualWidth, (int)source.Selection.ActualHeight));
        Clipboard.SetImage(cropped);
        

        source.Selection = null;
    }

    public override bool IsKeyPressed(KeyEventArgs args)
        => Keyboard.IsKeyDown(Key.LeftCtrl)
        && Keyboard.IsKeyDown(Key.C);
}
