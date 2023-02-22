using OperationSystemAndProgrammingLIB.Extensions;
using System.Windows.Input;

namespace Notepad.InputHadlers;

internal class IncreaseFontSizeKeyEventHandler : NotepadKeyEventHandler
{
    public override Key CallableCombination => Key.Add;

    public override ModifierKeys ModifierKey => ModifierKeys.Control;

    public override void HandleNotepadEvent(NotepadWindow source, KeyEventArgs? args) 
        => source.TextContainer.IncreaseSize();
}
