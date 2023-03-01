using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FileDiagnosing.PropertyProviders;

/// <summary>
/// Provides access to all file properties collectors.
/// </summary>
public static class FilePropertyProviderAccessor
{
    private static readonly List<IFilePropertyProvider?> _filePropertyProviders;

    /// <summary>
    /// Gets all property provider with the reflection.
    /// </summary>
    static FilePropertyProviderAccessor()
    {
        _filePropertyProviders = Assembly.GetAssembly(typeof(IFilePropertyProvider))?.GetTypes()
            .Where(t => t.IsAbstract == false && t.GetInterface(nameof(IFilePropertyProvider)) is not null)
            .Select(t => Activator.CreateInstance(t) as IFilePropertyProvider)
            .OrderBy(p => p!.DisplaingOrder)
            .ToList() ?? new List<IFilePropertyProvider?>();
    }

    /// <summary>
    /// Generate list of the <see cref="FileProperty"/> objects.
    /// </summary>
    /// <param name="filePath">Absolute path of the file.</param>
    /// <returns>All properties of the file stored in the list.</returns>
    internal static List<FileProperty> GetFileProperties(string filePath)
        => _filePropertyProviders.Where(provider => provider is not null)
                                 .Select(provider => new FileProperty()
                                 {
                                     PropertyTitle = provider!.PropertyTitle,
                                     PropertyValue = provider.PropertyValue(filePath)
                                 }).ToList();
}
