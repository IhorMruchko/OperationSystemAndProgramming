using Graphics.Extensions;
using ColorDialog = System.Windows.Forms.ColorDialog;
using DialogResult = System.Windows.Forms.DialogResult;

namespace Graphics.MenuOperations.PropertiesMenuOperations;

internal class FillColorMenuOperation : MenuOperation
{
    public override string Name => Constants.MenuOperationsSettings.Names.FILL_COLOR;

    public override string InputGestureText => Constants.MenuOperationsSettings.Keys.FILL_COLOR;

    public override string IconFileSource => Constants.IO.Images.Icons.FillColorIcon;

    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.FILL_COLOR;

    public override List<MenuOperation> GroupOperations => new();

    public override void HandleEvent(MainWindow source)
    {
        var colorDialog = new ColorDialog();
        source.Properties.FillColor = 
            colorDialog.ShowDialog() == DialogResult.OK 
            ? colorDialog.Color.ToBrush()
            : Constants.Properties.DefaultFillColor;
    }

    public override bool IsKeyPressed(KeyEventArgs args)
        => Keyboard.IsKeyDown(Key.LeftCtrl)
        && Keyboard.IsKeyDown(Key.F)
        && Keyboard.IsKeyDown(Key.C);
}
