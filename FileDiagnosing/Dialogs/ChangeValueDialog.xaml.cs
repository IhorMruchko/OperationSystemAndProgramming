using TranslatorLIB.Extensions;
using System.Windows;
using System.Windows.Controls;

namespace FileDiagnosing.Dialogs;

/// <summary>
/// Represents dialog class that changes invalid float value to the valid one.
/// </summary>
public partial class ChangeValueDialog : Window
{
    private string _previosValue = "0";

    /// <summary>
    /// Initializate dialog with title on the header.
    /// </summary>
    /// <param name="value">Value that cannot be parsed.</param>
    public ChangeValueDialog(string value)
    {
        InitializeComponent();
        ValueDisplayerLabel.Content = Constants.Formats.VALUE_CHANGE_FORMAT.Format(value);
    }

    /// <summary>
    /// Valid parsed value, inputed by the user.
    /// </summary>
    public float ChangedValue { get; private set; }

    /// <summary>
    /// Made file dialog to close.
    /// </summary>
    /// <param name="sender">Sender of the event.</param>
    /// <param name="e">Event arguments.</param>
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ChangedValue = float.Parse(ValueInputTextBox.Text);
        DialogResult = true;
    }

    /// <summary>
    /// Validates user input to valid float notation.
    /// </summary>
    /// <remarks>Used floating parser due to accepting integer values.</remarks>
    /// <param name="sender"><see cref="TextBox"/> that accepts user input.</param>
    /// <param name="e">Event arguments.</param>
    private void ValueInputTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (ValueInputTextBox.Text.Length == 0)
        {
            ValueInputTextBox.Text = "0";
            _previosValue = ValueInputTextBox.Text;
            ValueInputTextBox.CaretIndex = _previosValue.Length;
            return;
        }

        if (float.TryParse(ValueInputTextBox.Text, out _) == false)
        {
            ValueInputTextBox.Text = _previosValue;
            ValueInputTextBox.CaretIndex = _previosValue.Length;
            return;
        }

        _previosValue = ValueInputTextBox.Text;
    }
}
