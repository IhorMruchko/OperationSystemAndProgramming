using Graphics.Extensions;
using System.Linq;
using System.Windows.Controls;

namespace Graphics.MenuOperations;

public abstract class MenuOperation
{
    public abstract int DisplayOrder { get; }
    
    public virtual Key[] KeyBind { get; } = Array.Empty<Key>();
    
    protected abstract string Name { get; }

    protected abstract string IconFileSource { get; }

    public virtual List<MenuOperation> GroupOperations { get; } = new List<MenuOperation>();
    
    public virtual void HandleEvent(MainWindow source) { }
    
    protected string InputGestureText => string.Join(" + ", KeyBind);
    
    public bool IsKeyPressed() 
        => KeyBind.All(key => Keyboard.IsKeyDown(key));

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
