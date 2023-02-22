using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using Key = System.Windows.Input.Key;
using ModifierKeys = System.Windows.Input.ModifierKeys;
using System.Windows.Forms;
using System.Windows;
using OperationSystemAndProgrammingLIB.Extensions;

namespace Notepad.InputHadlers;

internal class FontChangerKeyEventHandler : NotepadKeyEventHandler
{
    public override Key CallableCombination => Key.F;

    public override ModifierKeys ModifierKey => ModifierKeys.Control;

    public override void HandleNotepadEvent(NotepadWindow source, KeyEventArgs? args)
    {
        var fontDialog = new FontDialog();
        if (fontDialog.ShowDialog() == DialogResult.OK)
            source.TextContainer.ChangeFont(fontDialog.Font);
    }
}
