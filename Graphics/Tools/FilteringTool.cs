using AForge.Imaging.Filters;
using System.Windows.Controls;
using Graphics.Extensions;
using System.Windows.Media.Imaging;
using Graphics.Commands;

namespace Graphics.Tools;

internal class FilteringTool : Tool
{
    private readonly IFilter _filter;

    public FilteringTool(IFilter filter)
    {
        _filter = filter;
    }

    protected override void OnMouseDown(MainWindow source, MouseEventArgs args)
    {
        if (args.OriginalSource is not Image image) return;

        var previousSource = image.Source;
        var currentSource = _filter.Apply(BitmapFrame.Create((BitmapSource)image.Source).ToBitmap()).ToImage();

        image.Source = currentSource;
        source.Actions.Add(new FilterAction(source, image, previousSource, currentSource));
        image.LayoutTransform = image.LayoutTransform;
        IsMouseDown = false;
    }

    protected override void OnMouseMove(MainWindow source, MouseEventArgs args)
    {
    }

    protected override void OnMouseUp(MainWindow source, MouseEventArgs args)
    {
    }
}
