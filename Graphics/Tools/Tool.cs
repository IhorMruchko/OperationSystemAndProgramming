using System.Windows;

namespace Graphics.Tools;

public abstract class Tool
{
    protected UIElement? Target { get; set; }

    protected Point PreviousMousePosition { get; set; }

    protected Point StartMousePosition { get; set; }

    protected bool IsMouseDown { get; set; }
    
    public void KeyDownEventHandler(MainWindow source, KeyEventArgs args)
    {
        if (args.Key.Equals(Key.Escape))
            Cancel(source);
    }

    public void MouseDownEventHandler(MainWindow source, MouseEventArgs args)
    {
        if (source.Selection is not null)
            source.PaintingCanvas.Children.Remove(source.Selection);

        IsMouseDown = true;
        OnMouseDown(source, args);
    }

    public void MouseMoveEventHandler(MainWindow source,  MouseEventArgs args)
    {
        if (IsMouseDown == false)
            return;

        OnMouseMove(source, args);
    }

    public void MouseUpEventHandler(MainWindow source, MouseEventArgs args)
    {
        if (IsMouseDown == false)
            return;

        IsMouseDown = false;
        PreviousMousePosition = new Point();
        OnMouseUp(source, args);
    }

    protected abstract void OnMouseDown(MainWindow source, MouseEventArgs args);
    
    protected abstract void OnMouseMove(MainWindow source, MouseEventArgs args);

    protected abstract void OnMouseUp(MainWindow source, MouseEventArgs args);

    protected virtual void Cancel(MainWindow source)
    {
        source.PaintingCanvas.Children.Remove(Target);
        PreviousMousePosition = new Point();
        IsMouseDown = false;
        Target = null;
    }

}
