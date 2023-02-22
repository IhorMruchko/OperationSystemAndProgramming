using System.Windows.Input;

namespace Notepad.InputHadlers;

internal class CreateNewFileKeyEventHandler : NotepadKeyEventHandler
{
    public override Key CallableCombination => Key.N;

    public override ModifierKeys ModifierKey => ModifierKeys.Control;

    public override void HandleNotepadEvent(NotepadWindow source, KeyEventArgs? args) 
        => source.LastFileOpenned = string.Empty;
}
