using Graphics.Commands;
using Graphics.Extensions;
using System.Windows;
using System.Windows.Controls;

namespace Graphics.Tools;

internal class MoveTool : Tool
{
    protected override void OnMouseDown(MainWindow source, MouseEventArgs args)
    {
        if (args.OriginalSource is not UIElement target 
            || target == source.Selection)
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
        if (Target is null || Target is Canvas) return;
        source.Actions.Add(new MovePaintingAction(source, Target, StartMousePosition, new Point(Canvas.GetLeft(Target), Canvas.GetTop(Target))));
        Target = null;
    }

    protected override void Cancel(MainWindow source)
    {
        Canvas.SetLeft(Target, StartMousePosition.X);
        Canvas.SetTop(Target, StartMousePosition.Y);
        PreviousMousePosition = new Point();
        IsMouseDown = false;
        Target = null;
    }
}
