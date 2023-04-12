namespace Graphics.MenuOperations.PropertiesMenuOperations;

internal class PropertiesMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.PROPERTIES;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.PROPERTIES;

    public override string IconFileSource => string.Empty;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.PROPERTIES;

    public override List<MenuOperation> GroupOperations => new()
    { 
        new StrokeColorMenuOperation(),
        new FillColorMenuOperation(),
        new StrokeSizeMenuOperation(),
    };

    public override void HandleEvent(MainWindow source)
    {
    }

    public override bool IsKeyPressed(KeyEventArgs args)
    {
        return false;
    }
}
