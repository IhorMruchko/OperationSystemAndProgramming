using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Graphics.BoundsValidators;

internal class RectangleBoundValidator : BoundValidator
{
    public override bool IsOutOfBounds(UIElement element, Canvas canvas, Point currentPosition, Point previousPosition)
    {
        var rectangle = (Rectangle)element;
        var x = Canvas.GetLeft(rectangle) + currentPosition.X - previousPosition.X;
        var y = Canvas.GetTop(rectangle) + currentPosition.Y - previousPosition.Y;
        var right = x + rectangle.ActualWidth;
        var bottom = y + rectangle.ActualHeight;

        NextPosition = new Point(x, y);

        return right > canvas.ActualWidth
            || bottom > canvas.ActualHeight
            || y < 0
            || x < 0;
    }

    public override bool IsTargettingType(UIElement element)
    {
        return element is Rectangle;
    }
}
