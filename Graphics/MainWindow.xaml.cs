using Graphics.MenuOperations;
using Graphics.MenuOperations.FileMenuOperations;
using Graphics.Objects;
using Graphics.Tools;
using System.Windows;

namespace Graphics;

public partial class MainWindow : Window
{
    private bool _isChangesMade;
    public bool IsChangesMade 
    { 
        get => _isChangesMade;
        set
        {
            _isChangesMade = value;
            Title = value ? Constants.TITLE_EDIT : Constants.TITLE;
        }
    }
    
    public string? OpennedFile { get; set; }

    public Tool? CurrentTool { get; set; } = new MoveTool();

    public FigureProperties Properties { get; set; } = new FigureProperties();
    
    public MainWindow()
    {
        InitializeComponent();
        Title = Constants.TITLE;
        MenuOperationManager.CreateMenu(ref OperationsMenu, this);
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        foreach(var handler in MenuOperationManager.AllOperations)
        {
            if (handler.IsKeyPressed(e))
            {
                handler.HandleEvent(this);
            }
        }
    }

    private void PaintingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        => CurrentTool?.MouseDownEventHandler(this, e);

    private void PaintingCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        => CurrentTool?.MouseUpEventHandler(this, e);

    private void PaintingCanvas_MouseMove(object sender, MouseEventArgs e) 
        => CurrentTool?.MouseMoveEventHandler(this, e);

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) 
        => new ExitMenuOperation().HandleEvent(this);
}
