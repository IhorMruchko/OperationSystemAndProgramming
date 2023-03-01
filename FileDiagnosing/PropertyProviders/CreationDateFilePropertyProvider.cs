using System.IO;

namespace FileDiagnosing.PropertyProviders;

internal class CreationDateFilePropertyProvider : IFilePropertyProvider
{
    public string PropertyTitle => Constants.Providers.CREATION_DATE;

    public int DisplaingOrder => Constants.Providers.CREATION_DATE_ORDER;

    public string PropertyValue(string filePath) 
        => File.GetCreationTime(filePath).ToString(Constants.Formats.DATE_TIME_FORMAT_TEXT);
}
