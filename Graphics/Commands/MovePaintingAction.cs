using System.Windows;
using System.Windows.Controls;

namespace Graphics.Commands;

public class MovePaintingAction : PaintingAction
{
    private Point _start;
    
    private Point _end;

    public MovePaintingAction(MainWindow source, UIElement element, Point startPoint, Point endPoint): base(source, element)
    {
        _start = startPoint;
        _end = endPoint;
    }
    
    public override void Undo()
    {
        var (top, left) = (Canvas.GetTop(Target), Canvas.GetLeft(Target));
        Canvas.SetLeft(Target, _start.X);
        Canvas.SetTop(Target, _start.Y);
    }

    public override void Redo()
    {
        Canvas.SetLeft(Target, _end.X);
        Canvas.SetTop(Target, _end.Y);
    }

}
