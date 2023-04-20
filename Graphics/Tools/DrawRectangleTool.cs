using Graphics.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Graphics.Tools;

internal class DrawRectangleTool : Tool
{
    protected override void OnMouseDown(MainWindow source, MouseEventArgs args)
    {
        PreviousMousePosition = args.GetPosition(source.PaintingCanvas);

        Target = new Rectangle()
        {
            Stroke = source.Properties.Forecolor,
            StrokeThickness = source.Properties.LineSize,
            Fill = source.Properties.FillColor,
        };
        
        Canvas.SetLeft(Target, PreviousMousePosition.X);
        Canvas.SetTop(Target, PreviousMousePosition.Y);
        
        source.PaintingCanvas.Children.Add(Target);
    }

    protected override void OnMouseMove(MainWindow source, MouseEventArgs args)
    {
        if (Target is null || Target is not Rectangle rectangle) return;

        var currentPosition = args.GetPosition(source.PaintingCanvas);
        double left = Min(PreviousMousePosition.X, currentPosition.X);
        double top = Min(PreviousMousePosition.Y, currentPosition.Y);
        var (width, height) = GetSizes(currentPosition);
        
        Canvas.SetLeft(Target, left);
        Canvas.SetTop(Target, top);

        rectangle.Width = width;
        rectangle.Height = height;
    }

    protected override void OnMouseUp(MainWindow source, MouseEventArgs args)
    {
        source.Actions.Add(new AddPaintingAction(source, Target, Canvas.GetLeft(Target), Canvas.GetTop(Target)));
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
