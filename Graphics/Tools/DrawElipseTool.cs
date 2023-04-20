using Graphics.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Graphics.Tools;

internal class DrawElipseTool : Tool
{    
    protected override void OnMouseDown(MainWindow source, MouseEventArgs args)
    {
        PreviousMousePosition = args.GetPosition(source.PaintingCanvas);
        Target = new Ellipse()
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
        if (Target is null || Target is not Ellipse ellipse) return;

        var currentMousePosition = args.GetPosition(source.PaintingCanvas);
        var (width, height) = GetSizes(currentMousePosition);
        
        Canvas.SetLeft(Target, Min(PreviousMousePosition.X, currentMousePosition.X));
        Canvas.SetTop(Target, Min(PreviousMousePosition.Y, currentMousePosition.Y));

        ellipse.Width = width;
        ellipse.Height = height;
    }

    protected override void OnMouseUp(MainWindow source, MouseEventArgs args)
    {
        source.Actions.Add(new AddPaintingAction(source, Target, Canvas.GetLeft(Target), Canvas.GetTop(Target)));
        Target = null;
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
