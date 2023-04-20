using System.Windows;
using System.Windows.Controls;

namespace Graphics.Commands;

internal class AddPaintingAction : PaintingAction
{
    private readonly double _left;
    private readonly double _top;

    public AddPaintingAction(MainWindow source, UIElement target, double left, double top) : base(source, target)
    {
        _left = left;
        _top = top;
    }

    public override void Redo()
    {
        Canvas.SetLeft(Target, _left);
        Canvas.SetTop(Target, _top);
        Source?.PaintingCanvas.Children.Add(Target);
    }

    public override void Undo()
    {
        Source?.PaintingCanvas.Children.Remove(Target);
    }
}
