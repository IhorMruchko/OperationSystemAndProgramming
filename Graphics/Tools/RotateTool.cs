using Graphics.Commands;
using System.Windows.Controls;
using System.Windows.Media;

namespace Graphics.Tools;

internal class RotateTool : Tool
{
    protected override void OnMouseDown(MainWindow source, MouseEventArgs args)
    {
        if (args.OriginalSource is not Image image) return;
        
        var direction = args.RightButton == MouseButtonState.Pressed ? -90 : 90;
        var degree = (image.LayoutTransform is RotateTransform t ? t.Angle : 0) + direction;
        
        image.LayoutTransform = new RotateTransform(degree);
        source.Actions.Add(new RotateAction(source, image, degree, direction));

        source.UpdateScrollBar();
        IsMouseDown = false;
    }

    protected override void OnMouseMove(MainWindow source, MouseEventArgs args)
    {
       
    }

    protected override void OnMouseUp(MainWindow source, MouseEventArgs args)
    {
       
    }
}
