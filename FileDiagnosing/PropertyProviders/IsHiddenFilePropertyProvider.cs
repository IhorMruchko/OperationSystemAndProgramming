using System.IO;

namespace FileDiagnosing.PropertyProviders;

/// <summary>
/// Checks is file hidden.
/// </summary>
internal class IsHiddenFilePropertyProvider : IFilePropertyProvider
{
    public string PropertyTitle => Constants.Providers.IS_HIDDEN;

    public int DisplaingOrder => Constants.Providers.IS_HIDDEN_ORDER;

    public string PropertyValue(string filePath) 
        => (File.GetAttributes(filePath) & FileAttributes.Hidden) == FileAttributes.Hidden
            ? Constants.Response.TRUE
            : Constants.Response.FALSE;
}
