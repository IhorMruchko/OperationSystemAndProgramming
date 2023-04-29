using Graphics.Extensions;
using Graphics.Objects;
using System.Windows;

namespace Graphics.MenuOperations.FileMenuOperations;

internal class NewMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.NEW;

    public override List<MenuOperation> GroupOperations => new();

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.N };

    protected override string Name => Constants.MenuOperationsSettings.Names.NEW;

    protected override string IconFileSource => Constants.IO.Images.Icons.NewFileIcon;

    public override void HandleEvent(MainWindow source)
    {
        if (source.IsChangesMade && Messages.ChangesMadeMessage == MessageBoxResult.Yes)
        {
            new SaveMenuOperation().HandleEvent(source);
            return;
        }

        if (Messages.LastResult == MessageBoxResult.Cancel)
            return;

        source.PaintingCanvas.Children.Clear();
        source.IsChangesMade = false;
    }
}
