using System.Windows;
using System.Windows.Controls;

namespace Graphics.BoundsValidators;

public class DefaultBoundValidator : BoundValidator
{
    public override bool IsOutOfBounds(UIElement element, Canvas canvas, Point currentPosition, Point previousPosition)
    {
        var x = Canvas.GetLeft(element) + currentPosition.X - previousPosition.X;
        var y = Canvas.GetTop(element) + currentPosition.Y - previousPosition.Y;
        
        NextPosition = new Point(x, y);

        return x < 0 || x > canvas.ActualWidth || y < 0 || y > canvas.ActualWidth;
    }

    public override bool IsTargettingType(UIElement element)
    {
        return true;
    }
}
