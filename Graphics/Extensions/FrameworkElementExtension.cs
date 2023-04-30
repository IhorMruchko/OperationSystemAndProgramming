using System.Windows;
using System.Windows.Media;

namespace Graphics.Extensions;

public static class FrameworkElementExtension
{
    public static double GetWidth(this FrameworkElement element) 
        => element.LayoutTransform is RotateTransform rotateTransform && (int)Abs(rotateTransform.Angle) % 180 != 0
           ? element.ActualHeight
           : element.ActualWidth;

    public static double GetHeight(this FrameworkElement element) 
        => element.LayoutTransform is RotateTransform rotateTransform && (int)Abs(rotateTransform.Angle) % 180 != 0
           ? element.ActualWidth
           : element.ActualHeight;
}
