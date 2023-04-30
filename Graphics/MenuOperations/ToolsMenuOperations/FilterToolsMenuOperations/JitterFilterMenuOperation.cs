using AForge.Imaging.Filters;
using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations.FilterToolsMenuOperations;

internal class JitterFilterMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.JITTER;

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.LeftShift, Key.J };

    protected override string Name => Constants.MenuOperationsSettings.Names.JITTER;

    protected override string IconFileSource => Constants.IO.Images.Icons.JitterIcon;

    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new FilteringTool(new Jitter(4));
    }
}
