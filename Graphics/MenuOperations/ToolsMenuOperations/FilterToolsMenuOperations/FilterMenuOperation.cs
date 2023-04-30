namespace Graphics.MenuOperations.ToolsMenuOperations.FilterToolsMenuOperations;

internal class FilterMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.FILTER;

    protected override string Name => Constants.MenuOperationsSettings.Names.FILTER;

    protected override string IconFileSource => Constants.IO.Images.Icons.FilterIcon;

    protected override bool InsertSeparator => true;

    public override List<MenuOperation> GroupOperations => new()
    {
        new GausianSharpenFilterMenuOperation(),
        new JitterFilterMenuOperation(),
        new GrayscaleFilterMenuOperation(),
        new WaterWaveFilterMenuOperation(),
    };
}
