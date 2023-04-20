using System.Windows;

namespace Graphics.Objects;

internal static class Messages
{
    public static MessageBoxResult LastResult;

    public static MessageBoxResult ChangesMadeMessage
    {
        get
        {
            LastResult = MessageBox.Show("Changes not saved. Save changes?",
                                         "Save changes",
                                         MessageBoxButton.YesNoCancel,
                                         MessageBoxImage.Question);
            return LastResult;
        }
    }
}
