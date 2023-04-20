using Graphics.Objects;

namespace Graphics.MenuOperations.PropertiesMenuOperations;

internal class StrokeSizeMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.THICKNESS;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.THICKNESS;

    public override string IconFileSource => Constants.IO.Images.Icons.ThicknessColorIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.THICKNESS;

    public override List<MenuOperation> GroupOperations => new();

    public override void HandleEvent(MainWindow source)
    {
        var numericDialog = new NumericDialog();
        if (numericDialog.ShowDialog() == true)
        {
            source.Properties.LineSize = numericDialog.Value;
        }
    }

    public override bool IsKeyPressed(KeyEventArgs args) 
        => Keyboard.IsKeyDown(Key.LeftCtrl)
        && Keyboard.IsKeyDown(Key.T);
}
