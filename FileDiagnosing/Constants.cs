using OperationSystemAndProgrammingLIB.Extensions;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileDiagnosing;

/// <summary>
/// Contains constants of the FileDiagnosting project.
/// </summary>
public static class Constants
{
    /// <summary>
    /// Constants that are related to file system.
    /// </summary>
    public static class IO
    {
        private const string PROBLEM_FOLDER_TITLE = "problem";
        private const string LOGGER_FILE_NAME_FOMRAT = "log_{0}.txt";
        public const string DAT_FILE_EXTENSION = ".dat";

        public static readonly string CURRENT_DIRRECTORY = Environment.CurrentDirectory;
        public static readonly string PROBLEM_FOLDER_DIRECTORY = Path.Combine(CURRENT_DIRRECTORY, PROBLEM_FOLDER_TITLE);
        public static readonly List<string> ACCEPTABLE_FILE_EXTENSIONS = new() { DAT_FILE_EXTENSION };

        public static string LOGGER_FILE_PATH => Path.Combine(CURRENT_DIRRECTORY,
                                                              LOGGER_FILE_NAME_FOMRAT.Format(DateTime.Now.ToString(Formats.DATE_TIME_FORMAT_FILE)));
    }

    /// <summary>
    /// Constants that are related to the logging.
    /// </summary>
    public static class Logging
    {
        private const char SEPARATOR = '=';
        private const int SEPARATOR_AMOUNT = 30;

        public static readonly string LOG_FORMAT = "Called: {0}\nResult: {1}\nExecutionDate: {2}\n" +
            new string(SEPARATOR, SEPARATOR_AMOUNT);
        public static readonly string VALUE_CHANGED_FORMAT = "Changed from {0} to {1} at line {2} on position {3}";
    }

    /// <summary>
    /// Constants that are formats for different cases.
    /// </summary>
    public static class Formats
    {
        public const string DATE_TIME_FORMAT_FILE = "yyy-MM-dd HH-mm-ss";
        public const string DATE_TIME_FORMAT_TEXT = "dd.MM.yyyy HH':'mm':'ss";

        public const string VALUE_CHANGE_FORMAT = "Cannot parse value {0}. Select another value instead.";
        public const string TOTAL_SUM_FORMAT = "Total sum of the file = {0}";
    }

    /// <summary>
    /// Constants of the property providers title and order.
    /// </summary>
    public static class Providers
    {
        public const string FULL_NAME = "Full name";
        public const string SIZE = "Size";
        public const string CREATION_DATE = "Created";
        public const string OPENNING_DATE = "Openned";
        public const string WRITTEN_DATE = "Written";
        public const string IS_READ_ONLY = "Read only";
        public const string IS_HIDDEN = "Hidden";

        public const int FULL_NAME_ORDER = 1;
        public const int SIZE_ORDER = 2;
        public const int CREATION_DATE_ORDER = 3;
        public const int OPENNING_DATE_ORDER = 4;
        public const int WRITTEN_DATE_ORDER = 5;
        public const int IS_READ_ONLY_ORDER = 6;
        public const int IS_HIDDEN_ORDER = 7;
    }

    /// <summary>
    /// Constatns of the possible responses.
    /// </summary>
    public static class Response
    {
        public const string TRUE = "True";
        public const string FALSE = "False";
    }
}
