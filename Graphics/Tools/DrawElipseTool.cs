using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Graphics.Tools;

internal class DrawElipseTool : Tool
{
    private Ellipse? _ellipse;
    
    protected override void OnMouseDown(MainWindow source, MouseEventArgs args)
    {
        PreviousMousePosition = args.GetPosition(source.PaintingCanvas);
        _ellipse = new Ellipse()
        {
            Stroke = source.Properties.Forecolor,
            StrokeThickness = source.Properties.LineSize,
            Fill = source.Properties.FillColor,
        };
        Canvas.SetLeft(_ellipse, PreviousMousePosition.X);
        Canvas.SetTop(_ellipse, PreviousMousePosition.Y);
        source.PaintingCanvas.Children.Add(_ellipse);
    }

    protected override void OnMouseMove(MainWindow source, MouseEventArgs args)
    {
        if (_ellipse is null) return;

        var currentMousePosition = args.GetPosition(source.PaintingCanvas);
        var (width, height) = GetSizes(currentMousePosition);
        
        Canvas.SetLeft(_ellipse, Min(PreviousMousePosition.X, currentMousePosition.X));
        Canvas.SetTop(_ellipse, Min(PreviousMousePosition.Y, currentMousePosition.Y));

        _ellipse.Width = width;
        _ellipse.Height = height;
    }

    protected override void OnMouseUp(MainWindow source, MouseEventArgs args)
    {
        _ellipse = null;
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
