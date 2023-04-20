using Graphics.Extensions;
using System.Linq;
using System.Windows.Controls;

namespace Graphics.MenuOperations;

public abstract class MenuOperation
{
    public abstract string Name { get; }
    
    public abstract string InputGestureText { get; }

    public abstract string IconFileSource { get; }

    public abstract int DisplayOrder { get; }

    public abstract List<MenuOperation> GroupOperations { get; }

    public abstract bool IsKeyPressed(KeyEventArgs args);

    public abstract void HandleEvent(MainWindow source);

    internal MenuItem CreateMenuItem()
    {
        var item = new MenuItem()
        {
            Header = Name,
            InputGestureText = InputGestureText,
            Icon = IconFileSource.CreateImage(),
        };

        item.Click += (_, args) => HandleEvent(MenuOperationManager.Source);

        foreach(var operation in GroupOperations.OrderBy(operation => operation.DisplayOrder))
        {
            item.Items.Add(operation.CreateMenuItem());
        }
        return item;
    }
}
