using System.Windows;
using System.Windows.Controls;

namespace Graphics.BoundsValidators;

internal class ImageBoundValidator : BoundValidator
{
    public override bool IsOutOfBounds(UIElement element, Canvas canvas, Point currentPosition, Point previousPosition)
    {
        var image = (Image)element;
        
        var x = Canvas.GetLeft(element) + currentPosition.X - previousPosition.X;
        var y = Canvas.GetTop(element) + currentPosition.Y - previousPosition.Y;
        var right = x + image.ActualWidth;
        var bottom = y + image.ActualHeight;

        NextPosition = new Point(x, y);

        return right > canvas.ActualWidth
            || bottom > canvas.ActualHeight
            || y < 0
            || x < 0;

    }

    public override bool IsTargettingType(UIElement element)
    {
        return element is Image;
    }
}
