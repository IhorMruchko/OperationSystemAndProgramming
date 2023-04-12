using System.Windows;

namespace Graphics.Objects;

public partial class NumericDialog : Window
{
    public int Value { get; private set; }

    public NumericDialog()
    {
        InitializeComponent();
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        if (int.TryParse(InputTextBox.Text, out int value))
        {
            Value = value;
            DialogResult = true;
        }
        else
        {
            MessageBox.Show("Invalid input. Please enter a valid integer value.");
        }
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
}