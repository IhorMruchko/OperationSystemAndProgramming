using System.IO;

namespace FileDiagnosing.PropertyProviders;

/// <summary>
/// Gets information about the file size in bytes.
/// </summary>
internal class SizeFilePropertyProvider : IFilePropertyProvider
{
    public string PropertyTitle => Constants.Providers.SIZE;

    public int DisplaingOrder => Constants.Providers.SIZE_ORDER;

    public string PropertyValue(string filePath) 
        => new FileInfo(filePath).Length.ToString() + " bytes";
}
