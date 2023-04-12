using Graphics.Extensions;
using System.Windows;

namespace Graphics.Tools;

internal class MoveTool : Tool
{
    private UIElement? _currentModifiedObject;

    protected override void OnMouseDown(MainWindow source, MouseEventArgs args)
    {
        if (args.OriginalSource is not UIElement target)
            return;
        _currentModifiedObject = target;
        PreviousMousePosition = target.TransformToAncestor(source.PaintingCanvas).Transform(args.GetPosition(target));
    }

    protected override void OnMouseMove(MainWindow source, MouseEventArgs args)
    {
        if (args.OriginalSource is not UIElement target)
            return;

        if (_currentModifiedObject != target && _currentModifiedObject is not null)
        {
            target = _currentModifiedObject;
        }

        PreviousMousePosition = source.PaintingCanvas.Move(target, args, PreviousMousePosition);
    }

    protected override void OnMouseUp(MainWindow source, MouseEventArgs args)
    {
        _currentModifiedObject = null;
    }
}
