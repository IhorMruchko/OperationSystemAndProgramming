using System.Windows.Input;

namespace Notepad.InputHadlers;

class SaveFileKeyEventHandler : NotepadKeyEventHandler
{
    public override Key CallableCombination => Key.S;

    public override ModifierKeys ModifierKey => ModifierKeys.Control;

    public override void HandleNotepadEvent(NotepadWindow source, KeyEventArgs? args)
    {
        source.SaveFile();
    }
}
