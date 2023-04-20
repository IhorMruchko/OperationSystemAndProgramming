using Graphics.Commands;
using Graphics.Extensions;
using System.Windows;
using System.Windows.Controls;

namespace Graphics.Tools;

internal class MoveTool : Tool
{
    protected override void OnMouseDown(MainWindow source, MouseEventArgs args)
    {
        if (args.OriginalSource is not UIElement target || target == source.CanvasBackGround)
            return;
        Target = target;
        PreviousMousePosition = target.TransformToAncestor(source.PaintingCanvas).Transform(args.GetPosition(target));
        StartMousePosition = new Point(Canvas.GetLeft(Target), Canvas.GetTop(Target));
    }

    protected override void OnMouseMove(MainWindow source, MouseEventArgs args)
    {
        if (args.OriginalSource is not UIElement target)
            return;

        if (Target != target && Target is not null)
        {
            target = Target;
        }

        PreviousMousePosition = source.PaintingCanvas.Move(target, args, PreviousMousePosition);
    }

    protected override void OnMouseUp(MainWindow source, MouseEventArgs args)
    {
        if (Target is null) return;
        source.Actions.Add(new MovePaintingAction(source, Target, StartMousePosition, new Point(Canvas.GetLeft(Target), Canvas.GetTop(Target))));
        Target = null;
    }
}
