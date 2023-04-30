using AForge.Imaging.Filters;
using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations.FilterToolsMenuOperations;

internal class GrayscaleFilterMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.GRAYSCALE;

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.G };

    protected override string Name => Constants.MenuOperationsSettings.Names.GRAYSCALE;

    protected override string IconFileSource => Constants.IO.Images.Icons.GrayscaleIcon;

    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new FilteringTool(new Grayscale(0.2125, 0.7154, 0.0721));
    }
}
