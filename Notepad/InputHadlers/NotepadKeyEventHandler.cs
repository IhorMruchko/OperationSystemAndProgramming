using OperationSystemAndProgrammingLIB.InputHandlers;
using System.Windows.Input;
using System.Windows;

namespace Notepad.InputHadlers;

/// <summary>
/// Specification for the Notepad project keyboard event handlers.
/// </summary>
internal abstract class NotepadKeyEventHandler : IKeyEventHandler
{
    public abstract Key CallableCombination { get; }

    public abstract ModifierKeys ModifierKey { get; }

    /// <summary>
    /// Reacts on the <see cref="NotepadWindow"/> key pressed.
    /// </summary>
    /// <param name="source">Window of the notepad.</param>
    /// <param name="args">Arguments of the key pressed event.</param>
    public abstract void HandleNotepadEvent(NotepadWindow source, KeyEventArgs? args);

    public virtual bool IsPressed(KeyEventArgs args) 
        => args.Key.Equals(CallableCombination) && Keyboard.Modifiers.Equals(ModifierKey);
    
    public void HadleEvent(Window source, KeyEventArgs? args) 
        => HandleNotepadEvent((NotepadWindow)source, args);
}
