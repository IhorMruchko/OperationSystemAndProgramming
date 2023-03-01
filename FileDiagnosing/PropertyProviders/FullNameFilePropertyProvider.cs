using System.IO;

namespace FileDiagnosing.PropertyProviders;

/// <summary>
/// Gets full name of the file.
/// </summary>
internal class FullNameFilePropertyProvider : IFilePropertyProvider
{
    public string PropertyTitle => Constants.Providers.FULL_NAME;

    public int DisplaingOrder => Constants.Providers.FULL_NAME_ORDER;

    public string PropertyValue(string filePath) 
        => Path.GetFullPath(filePath);
}
