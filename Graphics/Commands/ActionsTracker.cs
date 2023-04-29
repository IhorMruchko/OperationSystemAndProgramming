using System.Linq;

namespace Graphics.Commands;

public class ActionsTracker
{
    private readonly Stack<PaintingAction> _paintingAction = new();

    private readonly Stack<PaintingAction> _undoActions = new();

    public event Action? ChangesMade;

    public event Action? ChangesUndo;

    public event Action? ChangeUndo;

    public bool IsMadeActions => _paintingAction.Any();

    public void Undo()
    {
        if (_paintingAction.Any() == false)
        {
            return;
        }

        var undoAction = _paintingAction.Pop();
        
        undoAction.Undo();
        ChangeUndo?.Invoke();
        _undoActions.Push(undoAction); 
        
        if (_paintingAction.Any() == false)
        {
            ChangesUndo?.Invoke();
        }
    }

    public void Redo() 
    {
        if (_undoActions.Any() == false)
        {
            return;
        }
        
        ChangesMade?.Invoke();
        var redoAction = _undoActions.Pop();
        redoAction.Redo();
        _paintingAction.Push(redoAction);
    }

    public void Add(PaintingAction movePaintingAction)
    {
        _paintingAction.Push(movePaintingAction);
        ChangesMade?.Invoke();
    }

    public void Clear()
    {
        ChangesUndo?.Invoke();
        _paintingAction.Clear();
        _undoActions.Clear();
    }

    public void Cancel()
    {
        _paintingAction.TryPop(out _);
        if (_paintingAction.Any() == false)
        {
            ChangesUndo?.Invoke();
            return;
        }
    }
}
