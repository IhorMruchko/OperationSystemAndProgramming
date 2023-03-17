using Microsoft.Win32;
using TranslatorLIB.Extensions;
using System;
using System.IO;

namespace OperationSystemAndProgrammingLIB.Builders.FileDialogBuilder;

internal class DialogBuilder : ITittleSetter,
                               IDirectorySetter,
                               IDialogBuilder
{
    private string _title = string.Empty;
    private string _path = string.Empty;

    public IDirectorySetter SetTitle(string title)
    {
        if (title.Length > Constants.IO.ACCEPTABLE_TITLE_LENGHT)
            throw new ArgumentException(Constants.IO.INVALID_TITLE_LENGHT_EXCEPTION.Format(title.Length,
                                                                                           Constants.IO.ACCEPTABLE_TITLE_LENGHT));

        _title = title;
        return this;
    }

    public IDialogBuilder SetDirectory(string path)
    {
        if (Directory.Exists(path) == false)
            throw new ArgumentException(Constants.IO.DIRECTORY_NOT_EXISTS_ERROR.Format(path));

        _path = path;
        return this;
    }

    public OpenFileDialog CreateOpenFileDialog()
    {
        return new OpenFileDialog()
        {
            Title = _title,
            Filter = Constants.IO.TEXT_FILES_FORMAT,
            InitialDirectory = _path
        };
    }

    public SaveFileDialog CreateSaveFileDialog()
    {
        return new SaveFileDialog()
        {
            Title = _title,
            Filter = Constants.IO.TEXT_FILES_FORMAT,
            InitialDirectory = _path
        };
    }
}
