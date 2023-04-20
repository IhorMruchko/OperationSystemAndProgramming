using System.Windows.Media;

namespace Graphics.Objects;

public class FigureProperties
{
    public Brush Forecolor { get; set; } = Constants.Properties.DefaultStrokeColor;

    public Brush FillColor { get; set; } = Constants.Properties.DefaultFillColor;

    public int LineSize { get; set; } = Constants.Properties.DefaultStrokeThickness;
}
