namespace OperationSystemAndProgrammingLIB.Builders.FileDialogBuilder;

/// <summary>
/// Objects that can set title.
/// </summary>
public interface ITittleSetter
{
    /// <summary>
    /// Sets title of the dialog window.
    /// </summary>
    /// <param name="title">title of the dialog window.</param>
    /// <returns>Object that can set an initial dirrectory.</returns>
    IDirectorySetter SetTitle(string title);
}
