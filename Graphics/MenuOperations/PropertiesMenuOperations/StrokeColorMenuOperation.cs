using Graphics.Extensions;
using ColorDialog = System.Windows.Forms.ColorDialog;
using DialogResult = System.Windows.Forms.DialogResult;

namespace Graphics.MenuOperations.PropertiesMenuOperations
{
    internal class StrokeColorMenuOperation : MenuOperation
    {
        public override string Name => Constants.MenuOperationsSettings.Names.LINE_COLOR;

        public override string InputGestureText => Constants.MenuOperationsSettings.Keys.LINE_COLOR;

        public override string IconFileSource => Constants.IO.Images.Icons.LineColorIcon;

        public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.LINE_COLOR;

        public override List<MenuOperation> GroupOperations => new();

        public override void HandleEvent(MainWindow source)
        {
            var colorDialog = new ColorDialog();
            source.Properties.Forecolor =
                colorDialog.ShowDialog() == DialogResult.OK
                ? colorDialog.Color.ToBrush()
                : Constants.Properties.DefaultStrokeColor;
        }

        public override bool IsKeyPressed(KeyEventArgs args) 
            => Keyboard.IsKeyDown(Key.LeftCtrl)
            && Keyboard.IsKeyDown(Key.L)
            && Keyboard.IsKeyDown(Key.C);
    }
}
