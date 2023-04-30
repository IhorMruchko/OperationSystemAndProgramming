using Graphics.BoundsValidators;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Graphics.Extensions;

public static class CanvasExtension
{
    public static void LoadImage(this Canvas canvas, MainWindow source, string filePath, int left=0, int top=0)
    {
        var image = filePath.CreateImage();
        Canvas.SetTop(image, top);
        Canvas.SetLeft(image, left);
        image.Loaded += (_, _) => source.UpdateScrollBar();
        canvas.Children.Add(image);
    }

    public static void Save(this Canvas canvas, string filePath, double dpi=96.0)
    {
        var size = new Size(canvas.ActualWidth, canvas.ActualHeight);

        var visual = new DrawingVisual();
        using (var context = visual.RenderOpen())
        {
            context.DrawRectangle(Brushes.White, null, new Rect(new Point(), size));
            context.DrawRectangle(new VisualBrush(canvas), null, new Rect(new Point(), size));
        }

        var renderBitmap = new RenderTargetBitmap(
            (int)size.Width, (int)size.Height, dpi, dpi, PixelFormats.Pbgra32);
        renderBitmap.Render(visual);

        var encoder = new BmpBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
        using var fileStream = new FileStream(filePath, FileMode.Create);
        encoder.Save(fileStream);
    }

    public static Point Move(this Canvas canvas, UIElement element, MouseEventArgs args, Point previousMousePositon)
    {
        var currentPositon = element.TransformToAncestor(canvas).Transform(args.GetPosition(element));

        var validator = BoundValidatorsManager.GetValidator(element);
        if (validator.IsOutOfBounds(element, canvas, currentPositon, previousMousePositon))
            return currentPositon;

        Canvas.SetLeft(element, validator.NextPosition.X);
        Canvas.SetTop(element, validator.NextPosition.Y);

        return currentPositon;
    }

    public static CroppedBitmap Crop(this Canvas canvas, Rectangle borders)
    {
        var render = new RenderTargetBitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);
        canvas.Children.Remove(borders);
        render.Render(canvas);
        Debug.WriteLine(canvas.IsLoaded);
        Debug.WriteLine(render.Width);
        Debug.WriteLine(render.Height);
        Debug.WriteLine($"{Canvas.GetLeft(borders)}, {Canvas.GetTop(borders)} {borders.ActualWidth}, {borders.ActualHeight}");
        return new CroppedBitmap(render, new Int32Rect((int)Canvas.GetLeft(borders),
                                                       (int)Canvas.GetTop(borders),
                                                       (int)borders.ActualWidth,
                                                       (int)borders.ActualHeight));
    }
}
