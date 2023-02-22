using System.Windows.Input;

namespace Notepad.InputHadlers;

internal class DecreaseFontSizeKeyEventHandler : NotepadKeyEventHandler
{
    public override Key CallableCombination => Key.Subtract;

    public override ModifierKeys ModifierKey => ModifierKeys.Control;

    public override void HandleNotepadEvent(NotepadWindow source, KeyEventArgs? args)
    {
        source.TextContainer.FontSize -= 1;
    }
}
