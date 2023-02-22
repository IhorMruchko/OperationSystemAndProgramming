using Microsoft.Win32;

namespace OperationSystemAndProgrammingLIB.Builders.FileDialogBuilder; 

public interface IDialogBuilder 
{
    OpenFileDialog CreateOpenFileDialog();

    SaveFileDialog CreateSaveFileDialog();
}
