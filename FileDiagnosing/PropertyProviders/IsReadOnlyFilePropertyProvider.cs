using System.IO;

namespace FileDiagnosing.PropertyProviders;

/// <summary>
/// Checks is file read-only.
/// </summary>
internal class IsReadOnlyFilePropertyProvider : IFilePropertyProvider
{
    public string PropertyTitle => Constants.Providers.IS_READ_ONLY;

    public int DisplaingOrder => Constants.Providers.IS_READ_ONLY_ORDER;

    public string PropertyValue(string filePath) 
        => new FileInfo(filePath).IsReadOnly ? "True" : "False";
}
