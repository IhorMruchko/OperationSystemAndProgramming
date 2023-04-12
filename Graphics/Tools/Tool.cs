using System.Windows;

namespace Graphics.Tools;

public abstract class Tool
{
    protected Point PreviousMousePosition { get; set; }

    protected bool IsMouseDown { get; set; }
    
    public void MouseDownEventHandler(MainWindow source, MouseEventArgs args)
    {
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
        IsMouseDown = false;
        PreviousMousePosition = new Point();
        OnMouseUp(source, args);
    }

    protected abstract void OnMouseDown(MainWindow source, MouseEventArgs args);
    
    protected abstract void OnMouseMove(MainWindow source, MouseEventArgs args);

    protected abstract void OnMouseUp(MainWindow source, MouseEventArgs args);
}
