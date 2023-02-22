using System;

namespace OperationSystemAndProgrammingLIB;

public static class Constants
{
    public static class IO
    {
        public const int ACCEPTABLE_TITLE_LENGHT = 35;
        
        public const string TEXT_FILES_FORMAT = "Text files (*.txt)|*.txt";
        public const string DIRECTORY_NOT_EXISTS_ERROR = "Directory [{0}] does not exist.";
        public const string INVALID_TITLE_LENGHT_EXCEPTION = "Lenght of the title ({0}) is out of bound {1}.";
        public const string OPEN_FILE_TITLE = "Read text file.";
        public const string SAVE_FILE_TITLE = "Save text file.";

        public static readonly string DEFAULT_INITIAL_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
        
    }

    public static class App
    {
        public const string TITLE = "Notepad--";
        public const string TITLE_MODIFIED = "Notepad*";
    }
}
