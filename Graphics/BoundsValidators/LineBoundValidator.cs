using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Graphics.BoundsValidators;

internal class LineBoundValidator : BoundValidator
{
    public override bool IsOutOfBounds(UIElement element, Canvas canvas, Point currentPosition, Point previousPosition)
    {
        var line = (Line)element;
        var x = Canvas.GetLeft(line) + currentPosition.X - previousPosition.X;
        var y = Canvas.GetTop(line) + currentPosition.Y - previousPosition.Y;
        var right = x + line.ActualWidth;
        var bottom = y + line.ActualHeight;
        
        NextPosition = new Point(x, y);
        
        return x < 0 - Min(line.X1, line.X2)
            || y < 0 - Min(line.Y1, line.Y2)
            || right > canvas.ActualWidth
            || bottom > canvas.ActualHeight;
    }

    public override bool IsTargettingType(UIElement element)
    {
        return element is Line;
    }
}
