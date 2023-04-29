using Graphics.Objects;

namespace Graphics.MenuOperations.PropertiesMenuOperations;

internal class StrokeSizeMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.THICKNESS;

    public override List<MenuOperation> GroupOperations => new();

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.T };

    protected override string Name => Constants.MenuOperationsSettings.Names.THICKNESS;

    protected override string IconFileSource => Constants.IO.Images.Icons.ThicknessColorIcon;

    public override void HandleEvent(MainWindow source)
    {
        var numericDialog = new NumericDialog();
        if (numericDialog.ShowDialog() == true)
        {
            source.Properties.LineSize = numericDialog.Value;
        }
    }
}
