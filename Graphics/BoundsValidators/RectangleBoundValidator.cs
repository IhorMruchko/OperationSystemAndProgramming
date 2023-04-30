using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Graphics.BoundsValidators;

internal class RectangleBoundValidator : BoundValidator
{
    public override bool IsOutOfBounds(UIElement element, Canvas canvas, Point currentPosition, Point previousPosition)
    {
        var x = Canvas.GetLeft(element) + currentPosition.X - previousPosition.X;
        var y = Canvas.GetTop(element) + currentPosition.Y - previousPosition.Y;
        
        NextPosition = new Point(x, y);

        return y < 0 
            || x < 0;
    }

    public override bool IsTargettingType(UIElement element)
    {
        return element is Rectangle;
    }
}
