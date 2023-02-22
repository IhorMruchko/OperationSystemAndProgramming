using System.Windows.Forms;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using Key = System.Windows.Input.Key;
using ModifierKeys = System.Windows.Input.ModifierKeys;
using OperationSystemAndProgrammingLIB.Extensions;

namespace Notepad.InputHadlers;

internal class ColorChangeKeyEventHandler : NotepadKeyEventHandler
{
    public override Key CallableCombination => Key.K;

    public override ModifierKeys ModifierKey => ModifierKeys.Control;

    public override void HandleNotepadEvent(NotepadWindow source, KeyEventArgs? args)
    {
        var colorDialog = new ColorDialog();
        if (colorDialog.ShowDialog() == DialogResult.OK)
            source.TextContainer.ChangeForeground(colorDialog.Color);
    }
}

