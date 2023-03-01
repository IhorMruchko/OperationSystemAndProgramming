using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using FontFamily = System.Windows.Media.FontFamily;
using Color = System.Windows.Media.Color;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace OperationSystemAndProgrammingLIB.Extensions;

/// <summary>
/// Exntension class for the <see cref="TextBox"/> objects.
/// </summary>
public static class TextBoxExtensions
{
    /// <summary>
    /// Increases font size of the <see cref="TextBox"/> for one.
    /// </summary>
    /// <param name="source">Text box.</param>
    public static void IncreaseSize(this TextBox source)
        => source.FontSize += 1;

    /// <summary>
    /// Decreases font size of the <see cref="TextBox"/> for one.
    /// </summary>
    /// <param name="source">Text box.</param>
    public static void DecreaseSize(this TextBox source)
        => source.FontSize -= 1;

    /// <summary>
    /// Changes font of the <see cref="TextBox"/>.
    /// </summary>
    /// <param name="source">Text box.</param>
    /// <param name="font">Font parameters:
    /// Font family - <see cref="FontFamily"/><br/>
    /// Font weight - <see cref="FontWeights"/><br/>
    /// Font styles - <see cref="FontStyles"/><br/>
    /// Font decorations - <see cref="TextDecorations"/><br/>
    /// </param>
    public static void ChangeFont(this TextBox source, Font font)
    {
        source.TextDecorations.Clear();
        source.FontFamily = new FontFamily(font.Name);
        source.FontWeight = font.Bold ? FontWeights.Bold : FontWeights.Regular;
        source.FontStyle = font.Italic ? FontStyles.Italic : FontStyles.Normal;
        if (font.Underline)
            source.TextDecorations.Add(TextDecorations.Underline);
        if (font.Strikeout)
            source.TextDecorations.Add(TextDecorations.Strikethrough);
        source.FontSize = font.Size;
    }

    /// <summary>
    /// Changes font color of the <see cref="TextBox"/>.
    /// </summary>
    /// <param name="source">Text box.</param>
    /// <param name="color">Color <see cref="System.Drawing.Color"/>.</param>
    public static void ChangeForeground(this TextBox source, System.Drawing.Color color)
    {
        source.Foreground = new SolidColorBrush(Color.FromArgb(color.A,
                                                               color.R,
                                                               color.G,
                                                               color.B));
    }

    public static TextBox GenerateContent(this TextBox source, string text)
    {
        source.AcceptsTab = true;
        source.AcceptsReturn = true;
        source.IsReadOnly = true;
        source.Text = text;
        source.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
        return source;
    }
}
