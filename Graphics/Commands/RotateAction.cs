using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Graphics.Commands;

public class RotateAction : PaintingAction
{
    private double _rotationDegree;

    private int _direction;

    public RotateAction(MainWindow source, UIElement? target, double rotationDegree, int direction) : base(source, target)
    {
        _rotationDegree = rotationDegree;
        _direction = direction;
    }

    public override void Undo()
    {
        if (Target is not Image image) return;
        image.LayoutTransform = new RotateTransform(_rotationDegree - _direction);
    }

    public override void Redo()
    {
        if (Target is not Image image) return;
        image.LayoutTransform = new RotateTransform(_rotationDegree);
    }
}
