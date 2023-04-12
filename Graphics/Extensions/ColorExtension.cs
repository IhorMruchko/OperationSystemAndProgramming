using System.Windows.Media;

namespace Graphics.Extensions;

public static class ColorExtension
{
    public static SolidColorBrush ToBrush(this System.Drawing.Color color) 
        => new(Color.FromArgb(color.A,
                              color.R,
                              color.G,
                              color.B));
}
