using AForge.Imaging.Filters;
using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations.FilterToolsMenuOperations;

internal class GausianSharpenFilterMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.GAUSIAN_SHARPEN;

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.LeftShift, Key.G };

    protected override string Name => Constants.MenuOperationsSettings.Names.GAUSIAN_SHARPEN;

    protected override string IconFileSource => Constants.IO.Images.Icons.GausianSharpenIcon;

    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new FilteringTool(new GaussianSharpen(4, 11));
    }
}
