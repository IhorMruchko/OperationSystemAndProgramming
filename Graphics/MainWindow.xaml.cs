using Graphics.Commands;
using Graphics.MenuOperations;
using Graphics.MenuOperations.FileMenuOperations;
using Graphics.Objects;
using Graphics.Tools;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

    public Tool? CurrentTool { get; set; } = new MoveTool();

    public FigureProperties Properties { get; set; } = new FigureProperties();

    public ActionsTracker Actions { get; set; } = new ActionsTracker();

    public Rectangle? Selection { get; set; }
    
    public MainWindow()
    {
        InitializeComponent();
        Title = Constants.TITLE;
        MenuOperationManager.CreateMenu(ref OperationsMenu, this);
        Actions.ChangesMade += Actions_ChangesMade;
        Actions.ChangesUndo += Actions_ChangesUndo;
        Actions.ChangeUndo += Actions_ChangeUndo;
    }

    private void Actions_ChangeUndo()
        => UpdateScrollBar();

    public void UpdateScrollBar(SizeChangedEventArgs? e = null)
    {
        if (PaintingCanvas.Children.Count == 0)
        {
            PaintingCanvas.Width = double.NaN;
            PaintingCanvas.Height = double.NaN;
            return;
        }

        var (width, height) = e is null ? (ActualWidth, ActualHeight - OperationsMenu.ActualHeight) : (e.NewSize.Width, e.NewSize.Height - OperationsMenu.ActualHeight);
        var (maxWidth, maxHeight) = (PaintingCanvas.Children.OfType<FrameworkElement>().Max(element => Canvas.GetLeft(element) + element.ActualWidth),
            PaintingCanvas.Children.OfType<FrameworkElement>().Max(element => Canvas.GetTop(element) + element.ActualHeight));

        PaintingCanvas.Width = maxWidth < width ? double.NaN : maxWidth;
        PaintingCanvas.Height = maxHeight < height ? double.NaN : maxHeight;
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        CurrentTool?.KeyDownEventHandler(this, e);
        MenuOperationManager.HandleEvent(this);
    }

    private void PaintingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        => CurrentTool?.MouseDownEventHandler(this, e);

    private void PaintingCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        => CurrentTool?.MouseUpEventHandler(this, e);

    private void PaintingCanvas_MouseMove(object sender, MouseEventArgs e) 
        => CurrentTool?.MouseMoveEventHandler(this, e);
    private void Actions_ChangesUndo() 
        => Title = Constants.TITLE;

    private void Actions_ChangesMade()
    {
        Title = Constants.TITLE_EDIT;
        UpdateScrollBar();
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        new ExitMenuOperation().HandleEvent(this);
        if (Messages.LastResult == MessageBoxResult.Cancel)
        {
            e.Cancel = true;
        }
        Messages.LastResult = MessageBoxResult.None;
    }

    private void Window_SizeChanged(object sender, SizeChangedEventArgs e) 
        => UpdateScrollBar(e);
}
