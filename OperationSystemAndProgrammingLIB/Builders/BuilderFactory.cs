using OperationSystemAndProgrammingLIB.Builders.FileDialogBuilder;

namespace OperationSystemAndProgrammingLIB.Builders;

/// <summary>
/// Provides proper access to the builders.
/// </summary>
public static class BuilderFactory
{
    /// <summary>
    /// Gets Dialog builder as <see cref="ITittleSetter"/>.
    /// </summary>
    public static ITittleSetter DialogBuilder => new DialogBuilder();
}
