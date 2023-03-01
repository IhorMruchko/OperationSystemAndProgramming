using System.IO;

namespace FileDiagnosing.PropertyProviders;

/// <summary>
/// Gets information about the time file was openned.
/// </summary>
internal class OpenningDateFilePropertyProvider : IFilePropertyProvider
{
    public string PropertyTitle => Constants.Providers.OPENNING_DATE;

    public int DisplaingOrder => Constants.Providers.OPENNING_DATE_ORDER;

    public string PropertyValue(string filePath) 
        => File.GetLastAccessTime(filePath).ToString(Constants.Formats.DATE_TIME_FORMAT_TEXT);
}
