using System.Windows;

namespace Graphics.Commands;

public abstract class PaintingAction
{
    protected MainWindow? Source { get; set; }
    
    protected UIElement? Target { get; set; }

    public PaintingAction(MainWindow source, UIElement? target)
    {
        Source = source;
        Target = target;
    }

    public abstract void Undo();

    public abstract void Redo();
}