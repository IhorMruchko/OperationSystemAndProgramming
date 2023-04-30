using Graphics.Objects;
using System.Windows;

namespace Graphics.MenuOperations.FileMenuOperations;

internal class ExitMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.EXIT;

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.E };

    public override void HandleEvent(MainWindow source)
    {
        if (source.IsChangesMade && Messages.ChangesMadeMessage == MessageBoxResult.Yes)
        {
            new SaveMenuOperation().HandleEvent(source);
            return;
        }

        if (Messages.LastResult == MessageBoxResult.Cancel)
        {
            Messages.LastResult = MessageBoxResult.None;
            return;

        }
        source.Closing -= source.Window_Closing;
        Application.Current.Shutdown(0);
    }

    protected override string Name => Constants.MenuOperationsSettings.Names.EXIT;

    protected override string IconFileSource => Constants.IO.Images.Icons.ExitIcon;

}
