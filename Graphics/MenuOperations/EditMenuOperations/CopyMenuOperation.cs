using System.Diagnostics;
using System.Threading;
using System.Windows;
using Graphics.Extensions;

namespace Graphics.MenuOperations.EditMenuOperations;

internal class CopyMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.COPY;

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.C };

    protected override string Name => Constants.MenuOperationsSettings.Names.COPY;

    protected override string IconFileSource => Constants.IO.Images.Icons.CopyIcon;

    private MainWindow? Source { get; set; }

    private (double Vertical, double Horizontal) Offsets { get; set; }

    public override void HandleEvent(MainWindow source)
    {
        Source = source;
        source.ScrollBar.ScrollChanged += ScrollBar_ScrollChanged;
        Offsets = (source.ScrollBar.VerticalOffset, source.ScrollBar.HorizontalOffset);
        if (Offsets.Vertical == 0 && Offsets.Horizontal == 0)
        {
            ScrollBar_ScrollChanged(null, null);
            return;
        }
        source.ScrollBar.ScrollToTop();
        source.ScrollBar.ScrollToLeftEnd();
        source.InvalidateVisual();       
    }

    private void ScrollBar_ScrollChanged(object? sender, System.Windows.Controls.ScrollChangedEventArgs? e)
    {
        if (Source is null || Source.Selection is null) return;
        Clipboard.SetImage(Source.PaintingCanvas.Crop(Source.Selection));
        Source.Selection = null;
        Source.ScrollBar.ScrollChanged -= ScrollBar_ScrollChanged;
        Source.ScrollBar.ScrollToVerticalOffset(Offsets.Vertical);
        Source.ScrollBar.ScrollToHorizontalOffset(Offsets.Horizontal);
        Source.InvalidateVisual();
    }
}
