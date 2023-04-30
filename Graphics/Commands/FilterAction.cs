using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Graphics.Commands;

internal class FilterAction : PaintingAction
{
    private ImageSource _previousSource;
    private ImageSource _currentSource;
    
    public FilterAction(MainWindow source,  UIElement image, ImageSource prevSource,
        ImageSource currentSource): base(source, image)
    {
        _previousSource = prevSource;
        _currentSource = currentSource;
    }
    public override void Redo()
    {
        if (Target is not Image img) return;
        img.Source = _currentSource;
    }

    public override void Undo()
    {
        if (Target is not Image img) return;
        img.Source = _previousSource;
    }
}
