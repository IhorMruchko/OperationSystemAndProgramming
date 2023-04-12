using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphics.Tools;

internal class DrawRectangleTool : Tool
{
    private Rectangle? _rectangle;
    protected override void OnMouseDown(MainWindow source, MouseEventArgs args)
    {
        PreviousMousePosition = args.GetPosition(source.PaintingCanvas);

        _rectangle = new Rectangle()
        {
            Stroke = source.Properties.Forecolor,
            StrokeThickness = source.Properties.LineSize,
            Fill = source.Properties.FillColor,
        };
        
        Canvas.SetLeft(_rectangle, PreviousMousePosition.X);
        Canvas.SetTop(_rectangle, PreviousMousePosition.Y);
        
        source.PaintingCanvas.Children.Add(_rectangle);
    }

    protected override void OnMouseMove(MainWindow source, MouseEventArgs args)
    {
        if (_rectangle is null) return;

        var currentPosition = args.GetPosition(source.PaintingCanvas);
        double left = Min(PreviousMousePosition.X, currentPosition.X);
        double top = Min(PreviousMousePosition.Y, currentPosition.Y);
        var (width, height) = GetSizes(currentPosition);
        
        Canvas.SetLeft(_rectangle, left);
        Canvas.SetTop(_rectangle, top);
        
        _rectangle.Width = width;
        _rectangle.Height = height;
    }

    protected override void OnMouseUp(MainWindow source, MouseEventArgs args)
    {
        
    }

    private (double, double) GetSizes(Point currentMousePosition)
    {
        double width = Abs(currentMousePosition.X - PreviousMousePosition.X);
        double height = Abs(currentMousePosition.Y - PreviousMousePosition.Y);

        return Keyboard.IsKeyDown(Key.LeftShift)
            ? width > height
                ? (height, height)
                : (width, width)
            : (width, height);
    }
}
