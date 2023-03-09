using System;
using System.IO;

namespace OperationSystemAndProgrammingLIB.Helpers;

public static class IOHelper
{
    /// <summary>
    /// Creates file and writes all data.
    /// </summary>
    /// <param name="directory">Directory where file must be created.</param>
    /// <param name="fileName">Name of the file to create.</param>
    /// <param name="extension">File extension.</param>
    /// <param name="text">Text that will be written in the file.</param>
    /// <returns>File path to the new file.</returns>
    public static string CreateFile(string directory, string fileName, string extension, string text)
    {
        if (Directory.Exists(directory))
        {
            var path = Path.Combine(directory, fileName) + extension;
            File.WriteAllText(path, text);
            return path;
        }
        return string.Empty;
    }

    /// <summary>
    /// Creates file and writes all bytes.
    /// </summary>
    /// <param name="directory">Directory where file must be created.</param>
    /// <param name="fileName">Name of the file to create.</param>
    /// <param name="extension">File extension.</param>
    /// <param name="text">Text that will be written in the file.</param>
    /// <returns>File path to the new file.</returns>
    public static string CreateBinaryFile(string directory, string fileName, string extension, byte[] text)
    {
        if (Directory.Exists(directory))
        {
            var path = Path.Combine(directory, fileName) + extension;
            File.WriteAllBytes(path, text);
            return path;
        }
        return string.Empty;
    }

    /// <summary>
    /// Get from the user proper value of the file.
    /// </summary>
    /// <param name="displayableText">Text to display.</param>
    /// <param name="fileSourceValidator">Validates file source.</param>
    /// <returns>Valid file path.</returns>
    public static string ReadFile(string displayableText, Predicate<string?> fileSourceValidator)
    {
        string? filePath;
        
        do
        {
            filePath = ConsoleHelper.ReadLine(displayableText);
        }
        while (fileSourceValidator.Invoke(filePath) == false);
        
        return filePath!;
    }
}
