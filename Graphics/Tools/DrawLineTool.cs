using Graphics.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Graphics.Tools;

internal class DrawLineTool : Tool
{  
    protected override void OnMouseDown(MainWindow source, MouseEventArgs args)
    {
        PreviousMousePosition = args.GetPosition(source.PaintingCanvas);
        Target = new Line()
        {
            X1 = PreviousMousePosition.X,
            X2 = PreviousMousePosition.X,
            Y1 = PreviousMousePosition.Y,
            Y2 = PreviousMousePosition.Y,
            Stroke = source.Properties.Forecolor,
            StrokeThickness = source.Properties.LineSize
        };
        source.PaintingCanvas.Children.Add(Target);
    }

    protected override void OnMouseMove(MainWindow source, MouseEventArgs args)
    {
        if (Target is null || Target is not Line line) return;

        var currentPosition = args.GetPosition(source.PaintingCanvas);
        if (Keyboard.IsKeyDown(Key.LeftShift))
        {
            currentPosition = MakeDirrectLine(currentPosition);
        }
        line.X2 = currentPosition.X;
        line.Y2 = currentPosition.Y;
    }

    protected override void OnMouseUp(MainWindow source, MouseEventArgs args)
    {
        Canvas.SetLeft(Target, PreviousMousePosition.X);
        Canvas.SetTop(Target, PreviousMousePosition.Y);
        source.Actions.Add(new AddPaintingAction(source, Target, Canvas.GetLeft(Target), Canvas.GetTop(Target)));
        Target = null;
    }

    private Point MakeDirrectLine(Point currentPosition)
      => Abs(currentPosition.X - PreviousMousePosition.X) > Abs(currentPosition.Y - PreviousMousePosition.Y)
      ? new Point(currentPosition.X, PreviousMousePosition.Y)
      : new Point(PreviousMousePosition.X, currentPosition.Y);
}
