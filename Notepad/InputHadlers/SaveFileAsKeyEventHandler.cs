using OperationSystemAndProgrammingLIB;
using OperationSystemAndProgrammingLIB.Builders;
using System.Windows.Input;

namespace Notepad.InputHadlers;

internal class SaveFileAsKeyEventHandler : NotepadKeyEventHandler
{
    public override Key CallableCombination => Key.S;

    public override ModifierKeys ModifierKey => ModifierKeys.Control | ModifierKeys.Shift;

    public override void HandleNotepadEvent(NotepadWindow source, KeyEventArgs? args)
    {
        var saveFileDialog = BuilderFactory.DialogBuilder
            .SetTitle(Constants.IO.SAVE_FILE_TITLE)
            .SetDirectory(Constants.IO.DEFAULT_INITIAL_DIRECTORY)
            .CreateSaveFileDialog();

        if (saveFileDialog.ShowDialog() == true)
        {
            source.SaveFileAs(saveFileDialog.FileName);
        }
    }
}
