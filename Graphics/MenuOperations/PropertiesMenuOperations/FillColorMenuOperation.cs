using Graphics.Extensions;
using ColorDialog = System.Windows.Forms.ColorDialog;
using DialogResult = System.Windows.Forms.DialogResult;

namespace Graphics.MenuOperations.PropertiesMenuOperations;

internal class FillColorMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.FILL_COLOR;

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.F, Key.C };
    
    protected override string Name => Constants.MenuOperationsSettings.Names.FILL_COLOR;

    protected override string IconFileSource => Constants.IO.Images.Icons.FillColorIcon;

    public override void HandleEvent(MainWindow source)
    {
        var colorDialog = new ColorDialog();
        source.Properties.FillColor = 
            colorDialog.ShowDialog() == DialogResult.OK 
            ? colorDialog.Color.ToBrush()
            : Constants.Properties.DefaultFillColor;
    }
}
