namespace OperationSystemAndProgrammingLIB.Builders.FileDialogBuilder;

/// <summary>
/// Object that can set an initial dirrectory.
/// </summary>
public interface IDirectorySetter 
{
    /// <summary>
    /// Sets initial directory of the file dialog.
    /// </summary>
    /// <param name="path">Path of the initial direc</param>
    /// <returns></returns>
    IDialogBuilder SetDirectory(string path);
}
