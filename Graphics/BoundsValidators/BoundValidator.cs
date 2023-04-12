using System.Windows;
using System.Windows.Controls;

namespace Graphics.BoundsValidators;

public abstract class BoundValidator
{
    public Point NextPosition { get; protected set; }

    public abstract bool IsOutOfBounds(UIElement element, Canvas canvas, Point currentPosition, Point previousPosition);

    public abstract bool IsTargettingType(UIElement element);
}
