using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Graphics.BoundsValidators;

internal class EllipseBoundValidator : BoundValidator
{
    public override bool IsOutOfBounds(UIElement element, Canvas canvas, Point currentPosition, Point previousPosition)
    {
        var ellipse = (Ellipse)element;
        var x = Canvas.GetLeft(ellipse) + currentPosition.X - previousPosition.X;
        var y = Canvas.GetTop(ellipse) + currentPosition.Y - previousPosition.Y;
        var right = x + ellipse.ActualWidth;
        var bottom = y + ellipse.ActualHeight;

        NextPosition = new Point(x, y);

        return right > canvas.ActualWidth
            || bottom > canvas.ActualHeight
            || y < 0
            || x < 0;

    }

    public override bool IsTargettingType(UIElement element)
    {
        return element is Ellipse;
    }
}
