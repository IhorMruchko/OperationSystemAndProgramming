using FileDiagnosing.Dialogs;
using FileDiagnosing.PropertyProviders;
using OperationSystemAndProgrammingLIB.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FileDiagnosing;

/// <summary>
/// FileDiagnoser window that provides all needed functionality for the second lab.
/// </summary>
public partial class FileDiagnoser : Window
{
    private readonly List<string> _filePathes = new();
    private readonly StringBuilder _logger = new();
    private readonly string[] _directoryPathes = new string[]
    {
        Constants.IO.CURRENT_DIRRECTORY,
        Constants.IO.PROBLEM_FOLDER_DIRECTORY
    };
    
    public FileDiagnoser()
    {
        InitializeComponent();
        LoadFilePathes();
        InitializeCombobox();
        Title = OperationSystemAndProgrammingLIB.Constants.App.FILE_DIAGNOSING_TITLE;
    }

    /// <summary>
    /// Gets current file path if exists.
    /// </summary>
    private string CurrrentFilePath => _filePathes[FileSelectorComboBox.SelectedIndex];

    /// <summary>
    /// For every existing directory gets all files with acceptable extensions.
    /// </summary>
    private void LoadFilePathes()
    {
        foreach (var directory in _directoryPathes)
        {
            if (Directory.Exists(directory))
            {
                _filePathes.AddRange(Directory.GetFiles(directory)
                           .Where(file => Constants.IO.ACCEPTABLE_FILE_EXTENSIONS.Contains(Path.GetExtension(file))));
            }
        }
    }

    /// <summary>
    /// Initialize combobox with values finded in specified folders.
    /// </summary>
    /// <remarks>
    /// Acceptable folders:<br/>
    /// <see cref="Constants.IO.CURRENT_DIRRECTORY"/> <br/>
    /// <see cref="Constants.IO.PROBLEM_FOLDER_DIRECTORY"/><br/>
    /// If files of the <see cref="Constants.IO.ACCEPTABLE_FILE_EXTENSIONS"/> are not found - disable all buttons.
    /// </remarks>
    private void InitializeCombobox()
    {
        FileSelectorComboBox.ItemsSource = _filePathes.Select(file => Path.GetFileName(file));
        if (_filePathes.Any() == false)
        {
            ChangeButtonEnability();
            return;
        }
        ChangeButtonEnability(true);
        FileSelectorComboBox.SelectedIndex = 0;
    }

    /// <summary>
    /// Finds all buttons that are responsible for realisation second lab's tasks and 
    /// makes them enabled or disabled based on <paramref name="isEnabled"/>
    /// </summary>
    /// <param name="isEnabled">Defines is buttons are enabled or disabled.</param>
    private void ChangeButtonEnability(bool isEnabled = false)
    {
        foreach(var button in ButtonsContainer.Children.OfType<Button>())
            button.IsEnabled = isEnabled;
    }

    /// <summary>
    /// If users add or removes files from the specified directories,
    /// revalidates state of the window.
    /// </summary>
    /// <remarks>
    /// Acceptable folders:<br/>
    /// <see cref="Constants.IO.CURRENT_DIRRECTORY"/> <br/>
    /// <see cref="Constants.IO.PROBLEM_FOLDER_DIRECTORY"/><br/>
    /// <br/>
    /// Changes of the window:
    /// <list type="bullet">
    /// <item>Disable buttons.</item>
    /// <item>Changes combobox value.</item>
    /// </list> 
    /// </remarks>
    /// <param name="sender"><see cref="Button"/> object.</param>
    /// <param name="e">Event arguments.</param>
    private void RefindFilesButton_Click(object sender, RoutedEventArgs e)
    {
        _filePathes.Clear();
        LoadFilePathes();
        InitializeCombobox();
    }

    /// <summary>
    /// Displays file name of the current selected file.
    /// </summary>
    /// <param name="sender"><see cref="Button"/> object.</param>
    /// <param name="e">Event arguments.</param>
    private void ShowFileNameButton_Click(object sender, RoutedEventArgs e)
    {
        var result = FileSelectorComboBox.Items[FileSelectorComboBox.SelectedIndex];
        ResultViewerContentControl.Content = new TextBox().GenerateContent(result.ToString()!);
        
        _logger.AppendLine(Constants.Logging.LOG_FORMAT.Format(nameof(ShowFileNameButton_Click),
                                                               result,
                                                               DateTime.Now.ToString(Constants.Formats.DATE_TIME_FORMAT_TEXT)));
    }

    /// <summary>
    /// Displays absolute file path of the current file.
    /// </summary>
    /// <param name="sender"><see cref="Button"/> object.</param>
    /// <param name="e">Event arguments.</param>
    private void ShowFullFilePathButton_Click(object sender, RoutedEventArgs e)
    {
        var result = CurrrentFilePath;
        ResultViewerContentControl.Content = new TextBox().GenerateContent(result);

        _logger.AppendLine(Constants.Logging.LOG_FORMAT.Format(nameof(ShowFullFilePathButton_Click),
                                                               result,
                                                               DateTime.Now.ToString(Constants.Formats.DATE_TIME_FORMAT_TEXT)));
    }

    /// <summary>
    /// Displays all properties of the file.
    /// </summary>
    /// <param name="sender"><see cref="Button"/> object.</param>
    /// <param name="e">Event arguments.</param>
    private void ShowAllPropertiesButton_Click(object sender, RoutedEventArgs e)
    {
        var result = FilePropertyProviderAccessor.GetFileProperties(CurrrentFilePath);
        ResultViewerContentControl.Content = GenerateGridContent(result);

        _logger.AppendLine(Constants.Logging.LOG_FORMAT.Format(nameof(ShowAllPropertiesButton_Click),
                                                               $"\n\t{"\n\t".JoinString(result.Select(p => $"{p.PropertyTitle} = {p.PropertyValue}"))}",
                                                               DateTime.Now.ToString(Constants.Formats.DATE_TIME_FORMAT_TEXT)));
    }

    /// <summary>
    /// Displays text of the file without OpenFileDialog.
    /// </summary>
    /// <param name="sender"><see cref="Button"/> object.</param>
    /// <param name="e">Event arguments.</param>
    private void DisplayFileTextButton_Click(object sender, RoutedEventArgs e)
    {
        var result = File.ReadAllLines(CurrrentFilePath);
        ResultViewerContentControl.Content = new TextBox().GenerateContent("\n".JoinString(result));

        _logger.AppendLine(Constants.Logging.LOG_FORMAT.Format(nameof(DisplayFileTextButton_Click),
                                                               $"\n\t{"\n\t".JoinString(result)}",
                                                               DateTime.Now.ToString(Constants.Formats.DATE_TIME_FORMAT_TEXT)));
    }

    /// <summary>
    /// Evaluates sum of the numbers in the current file.
    /// </summary>
    /// <param name="sender"><see cref="Button"/> object.</param>
    /// <param name="e">Event arguments.</param>
    private void EvaluateSumButton_Click(object sender, RoutedEventArgs e)
    {
        var values = File.ReadAllLines(CurrrentFilePath).Select(line => line.Split()).ToArray();
        var totalFileSum = EvaluateSum(values, out var changes);
        ResultViewerContentControl.Content = GenerateEvaluatedContent(totalFileSum, changes);

        _logger.AppendLine(
            Constants.Logging.LOG_FORMAT.Format(nameof(EvaluateSumButton_Click),
            Environment.NewLine + Constants.Formats.TOTAL_SUM_FORMAT.Format(totalFileSum) + Environment.NewLine + changes,
            DateTime.Now.ToString(Constants.Formats.DATE_TIME_FORMAT_TEXT)));
    }

    /// <summary>
    /// Changes current selected file.
    /// </summary>
    /// <param name="sender"><see cref="ComboBox"/> object.</param>
    /// <param name="e">Event arguments.</param>
    private void FileSelectorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ResultViewerContentControl.Content = null;
    }

    /// <summary>
    /// Saves all logged actions of the user before window closed.
    /// </summary>
    /// <remarks>
    /// If user have not done any activity file would not bee created.
    /// </remarks>
    /// <param name="sender"><see cref="Window"/> object.</param>
    /// <param name="e">Event arguments</param>
    private void Window_Closing(object sender, CancelEventArgs e)
    {
        if (_logger.Length == 0)
        {
            return;
        }
        File.WriteAllText(Constants.IO.LOGGER_FILE_PATH, _logger.ToString());
    }

    /// <summary>
    /// Generates view of the properties based on <see cref="FileProperty"/> list.
    /// </summary>
    /// <param name="properties">All parsed file properties.</param>
    /// <returns><see cref="Grid"/> that contains <see cref="Label"/> and <see cref="TextBox"/> with file properties value.</returns>
    private static object GenerateGridContent(List<FileProperty> properties)
    {
        var grid = new Grid();
        grid.ColumnDefinitions.Add(new ColumnDefinition());
        grid.ColumnDefinitions.Add(new ColumnDefinition());

        for (var i = 0; i < properties.Count; ++i)
        {
            grid.RowDefinitions.Add(new RowDefinition());
            
            var label = new Label().GenerateContent(properties[i].PropertyTitle);
            var textBox = new TextBox()
            {
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            }.GenerateContent(properties[i].PropertyValue);
            
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, i);
            Grid.SetColumn(textBox, 1);
            Grid.SetRow(textBox, i);
            
            grid.Children.Add(label);
            grid.Children.Add(textBox);
        }
        return grid;
    }

    /// <summary>
    /// Displays result of the sum evaluation.
    /// </summary>
    /// <remarks>
    /// Contains total sum value and all changes made durring the evaluation.
    /// </remarks>
    /// <param name="totalFileSum">Sum of the numbers in the current file.</param>
    /// <param name="changes">List of changes made durring the evaluation.</param>
    /// <returns><see cref="Grid"/> that contains results of the evaluation.</returns>
    private static Grid GenerateEvaluatedContent(float totalFileSum, string changes)
    {
        var grid = new Grid();
        grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
        grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(4, GridUnitType.Star) });
        
        var label = new Label().GenerateContent(Constants.Formats.TOTAL_SUM_FORMAT.Format(totalFileSum));
        var textBox = new TextBox().GenerateContent(changes);
        
        Grid.SetRow(textBox, 1);
        
        grid.Children.Add(label);
        grid.Children.Add(textBox);
        return grid;
    }

    /// <summary>
    /// Evaluates sum based on all lines.
    /// </summary>
    /// <param name="values">Values separated by lines and spaces.</param>
    /// <param name="changedValues">Out param that contains logs of all changes user made.</param>
    /// <returns>Sum of the numbers written in the file.</returns>
    private static float EvaluateSum(string[][] values, out string changedValues)
    {
        var sum = .0f;
        var changedValuesBuilder = new StringBuilder();
        var skipedInLine = 0;
        for(var lineNumber = 0; lineNumber < values.Length; ++lineNumber)
        {
            for (var positionNumber = 0; positionNumber < values[lineNumber].Length; ++positionNumber)
            {
                var currentValue = values[lineNumber][positionNumber];
                if (currentValue.Equals(string.Empty))
                {
                    ++skipedInLine;
                    continue;
                }
                if (float.TryParse(currentValue, out var parsedValue))
                {
                    sum += parsedValue;
                }
                else
                {
                    var changed = DisplayErrorDialog(currentValue);
                    sum += changed;
                    changedValuesBuilder.AppendLine(Constants.Logging.VALUE_CHANGED_FORMAT.Format(currentValue,
                                                                                                  changed,
                                                                                                  lineNumber + 1,
                                                                                                  positionNumber + 1 - skipedInLine));
                } 
            }
            skipedInLine = 0;
        }
        changedValues = changedValuesBuilder.ToString();
        return sum;
    }

    /// <summary>
    /// Displays dialog where user can change invalid value to the valid one.
    /// </summary>
    /// <param name="value">Invalid value that cannot be parsed.</param>
    /// <returns>Changed value by the user.</returns>
    private static float DisplayErrorDialog(string value)
    {
        var changeValueDialog = new ChangeValueDialog(value);
        changeValueDialog.ShowDialog();
        return changeValueDialog.ChangedValue;
    }
}
