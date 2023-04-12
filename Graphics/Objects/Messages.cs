using System.Windows;

namespace Graphics.Objects;

internal static class Messages
{
    public static MessageBoxResult ChangesMadeMessage
        => MessageBox.Show("Changes not saved. Save changes?",
                           "Save changes",
                           MessageBoxButton.OKCancel,
                           MessageBoxImage.Question);
}
