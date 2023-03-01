using System.Windows;
using System.Windows.Controls;

namespace OperationSystemAndProgrammingLIB.Extensions;

/// <summary>
/// Extension class of the <see cref="Label"/> objects.
/// </summary>
public static class LabelExtensions
{
    /// <summary>
    /// Sets aligment to the center and provides needed content.
    /// </summary>
    /// <param name="label">Lable to centerilize and set content.</param>
    /// <param name="content">Value of the label content.</param>
    /// <returns></returns>
    public static Label GenerateContent(this Label label, object content)
    {
        label.HorizontalAlignment = HorizontalAlignment.Center;
        label.VerticalAlignment = VerticalAlignment.Center;
        label.Content = content;
        return label;
    }
}
