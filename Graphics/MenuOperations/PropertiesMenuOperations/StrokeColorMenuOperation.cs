using Graphics.Extensions;
using ColorDialog = System.Windows.Forms.ColorDialog;
using DialogResult = System.Windows.Forms.DialogResult;

namespace Graphics.MenuOperations.PropertiesMenuOperations
{
    internal class StrokeColorMenuOperation : MenuOperation
    {
        public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.LINE_COLOR;

        public override List<MenuOperation> GroupOperations => new();

        protected override string Name => Constants.MenuOperationsSettings.Names.LINE_COLOR;

        protected override string IconFileSource => Constants.IO.Images.Icons.LineColorIcon;

        public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.L, Key.C };

        public override void HandleEvent(MainWindow source)
        {
            var colorDialog = new ColorDialog();
            source.Properties.Forecolor =
                colorDialog.ShowDialog() == DialogResult.OK
                ? colorDialog.Color.ToBrush()
                : Constants.Properties.DefaultStrokeColor;
        }
    }
}
