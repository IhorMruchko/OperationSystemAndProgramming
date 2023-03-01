using System.IO;

namespace FileDiagnosing.PropertyProviders;

/// <summary>
/// Gets infromation about the last time when file was written.
/// </summary>
internal class WrittenDateFilePropertyProvider : IFilePropertyProvider
{
    public string PropertyTitle => Constants.Providers.WRITTEN_DATE;

    public int DisplaingOrder => Constants.Providers.WRITTEN_DATE_ORDER;

    public string PropertyValue(string filePath) 
        => File.GetLastWriteTime(filePath).ToString(Constants.Formats.DATE_TIME_FORMAT_TEXT);
}
