using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphics.Tools;

internal class DrawLineTool : Tool
{
    private Line? _line;
    
    protected override void OnMouseDown(MainWindow source, MouseEventArgs args)
    {
        PreviousMousePosition = args.GetPosition(source.PaintingCanvas);
        _line = new Line()
        {
            X1 = PreviousMousePosition.X,
            X2 = PreviousMousePosition.X,
            Y1 = PreviousMousePosition.Y,
            Y2 = PreviousMousePosition.Y,
            Stroke = source.Properties.Forecolor,
            StrokeThickness = source.Properties.LineSize
        };
        source.PaintingCanvas.Children.Add(_line);
    }

    protected override void OnMouseMove(MainWindow source, MouseEventArgs args)
    {
        if (_line is null) return;

        var currentPosition = args.GetPosition(source.PaintingCanvas);
        if (Keyboard.IsKeyDown(Key.LeftShift))
        {
            currentPosition = MakeDirrectLine(currentPosition);
        }
        _line.X2 = currentPosition.X;
        _line.Y2 = currentPosition.Y;
    }

    protected override void OnMouseUp(MainWindow source, MouseEventArgs args)
    {
        Canvas.SetLeft(_line, PreviousMousePosition.X);
        Canvas.SetTop(_line, PreviousMousePosition.Y);
        _line = null;
    }

    private Point MakeDirrectLine(Point currentPosition)
      => Abs(currentPosition.X - PreviousMousePosition.X) > Abs(currentPosition.Y - PreviousMousePosition.Y)
      ? new Point(currentPosition.X, PreviousMousePosition.Y)
      : new Point(PreviousMousePosition.X, currentPosition.Y);
}
