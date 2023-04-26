using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphics.Tools;

internal class DrawSelectionTool : DrawRectangleTool
{
    protected override void OnMouseDown(MainWindow source, MouseEventArgs args)
    {
        base.OnMouseDown(source, args);
        
        if (Target is not Rectangle rectangle) return;
        
        rectangle.Stroke = Brushes.LightBlue;
        rectangle.StrokeThickness = 2;
        rectangle.Fill = Brushes.Transparent;
        rectangle.StrokeDashArray = new DoubleCollection(new double[] { 4, 2 });
    }

    protected override void OnMouseUp(MainWindow source, MouseEventArgs args)
    {
        base.OnMouseUp(source, args);
        source.Actions.Cancel();
        source.Selection = Target as Rectangle;
    }
}
