namespace Graphics.MenuOperations.PropertiesMenuOperations;

internal class PropertiesMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.PROPERTIES;

    public override List<MenuOperation> GroupOperations => new()
    { 
        new StrokeColorMenuOperation(),
        new FillColorMenuOperation(),
        new StrokeSizeMenuOperation(),
    };

    protected override string Name => Constants.MenuOperationsSettings.Names.PROPERTIES;

    protected override string IconFileSource => string.Empty;

}
