using OperationSystemAndProgrammingLIB;
using OperationSystemAndProgrammingLIB.Builders;
using System.Windows.Input;

namespace Notepad.InputHadlers;

internal class OpenFileKeyEventHandler : NotepadKeyEventHandler
{
    public override Key CallableCombination => Key.O;

    public override ModifierKeys ModifierKey => ModifierKeys.Control;

    public override void HandleNotepadEvent(NotepadWindow source, KeyEventArgs? args)
    {
        var dialog = BuilderFactory.DialogBuilder
            .SetTitle(Constants.IO.OPEN_FILE_TITLE)
            .SetDirectory(Constants.IO.DEFAULT_INITIAL_DIRECTORY)
            .CreateOpenFileDialog();

        if (dialog.ShowDialog() == true)
        {
            source.LastFileOpenned = dialog.FileName;
        }
    }
}
