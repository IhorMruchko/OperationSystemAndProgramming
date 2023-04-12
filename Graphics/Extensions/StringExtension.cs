using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Graphics.Extensions;

public static class StringExtension
{
    public static Image? CreateImage(this string filePath)
    {
        try
        {
            return new Image() { Source = TryCreate(filePath) };
        }
        catch
        {
            Debug.WriteLine($"Cannot load image from [{filePath}]");
            return null;
        }
    }

    private static BitmapImage TryCreate(string filePath)
    {
        var image = new BitmapImage();
        
        image.BeginInit();
        image.UriSource = new Uri(filePath);
        image.EndInit();

        return image;
    }
}
