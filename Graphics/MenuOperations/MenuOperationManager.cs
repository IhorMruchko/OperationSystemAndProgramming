using Graphics.Extensions;
using Graphics.MenuOperations.ActionMenuOperations;
using Graphics.MenuOperations.EditMenuOperations;
using Graphics.MenuOperations.FileMenuOperations;
using Graphics.MenuOperations.PropertiesMenuOperations;
using Graphics.MenuOperations.ToolsMenuOperations;
using System.Linq;
using System.Windows.Controls;

namespace Graphics.MenuOperations;

internal static class MenuOperationManager
{
    // TODO: Add edit menu operators.
    private static readonly List<MenuOperation> _operations = new()
    {
        new FileMenuOperation(),
        new ToolsMenuOperation(),
        new PropertiesMenuOperation(),
        new ActionMenuOperation(),
        new EditMenuOperation()
    };

    public static List<MenuOperation> Operations => _operations.OrderBy(operation => operation.DisplayOrder).ToList();

    public static List<MenuOperation> AllOperations => _operations.GetOperations();

    public static MainWindow Source { get; private set; }

    internal static void CreateMenu(ref Menu result, MainWindow source)
    {
        Source = source;
        foreach (var node in Operations) 
            result.Items.Add(node.CreateMenuItem());
    }

    internal static void HandleEvent(MainWindow mainWindow, KeyEventArgs e)
    {
        AllOperations.OrderBy(t => t.DisplayOrder).FirstOrDefault(handler => handler.IsKeyPressed(e))?.HandleEvent(mainWindow);
    }
}
