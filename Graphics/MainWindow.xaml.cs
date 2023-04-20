using Graphics.Commands;
using Graphics.MenuOperations;
using Graphics.MenuOperations.FileMenuOperations;
using Graphics.Objects;
using Graphics.Tools;
using System.Windows;
using System.Windows.Shapes;

namespace Graphics;

public partial class MainWindow : Window
{
    public bool IsChangesMade
    {
        get => Actions.IsMadeActions;
        set 
        {
            if (value is false)
            {
                Actions.Clear();
            }    
        }
    }
    
    public string? OpennedFile { get; set; }

    public Tool? CurrentTool { get; set; } = new MoveTool();

    public FigureProperties Properties { get; set; } = new FigureProperties();

    public ActionsTracker Actions { get; set; } = new ActionsTracker();

    public Rectangle? Selection { get; set; }
    
    public MainWindow()
    {
        InitializeComponent();
        Title = Constants.TITLE;
        MenuOperationManager.CreateMenu(ref OperationsMenu, this);
        Actions.ChangesMade += Actions_ChangesMange;
        Actions.ChangesUndo += Actions_ChangesUndo;
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        CurrentTool?.KeyDownEventHandler(this, e);
        MenuOperationManager.HandleEvent(this, e);
    }

    private void PaintingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        => CurrentTool?.MouseDownEventHandler(this, e);

    private void PaintingCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        => CurrentTool?.MouseUpEventHandler(this, e);

    private void PaintingCanvas_MouseMove(object sender, MouseEventArgs e) 
        => CurrentTool?.MouseMoveEventHandler(this, e);
    private void Actions_ChangesUndo() => Title = Constants.TITLE;

    private void Actions_ChangesMange() => Title = Constants.TITLE_EDIT;

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        new ExitMenuOperation().HandleEvent(this);
        if (Messages.LastResult == MessageBoxResult.Cancel)
        {
            e.Cancel = true;
        }
    }
}
