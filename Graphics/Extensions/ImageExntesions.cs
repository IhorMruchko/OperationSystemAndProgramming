using Bitmap = System.Drawing.Bitmap;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Graphics.Extensions;

public static class ImageExntesions
{
    public static Bitmap ToBitmap(this BitmapFrame source)
    {
        using var stream = new MemoryStream();
        new BmpBitmapEncoder()
        {
            Frames = new List<BitmapFrame>() { BitmapFrame.Create(source) }
        }.Save(stream);
        return new Bitmap(stream);
    }

    public static BitmapSource ToImage(this Bitmap source) 
        => Imaging.CreateBitmapSourceFromHBitmap(source.GetHbitmap(),
                                                 IntPtr.Zero,
                                                 Int32Rect.Empty,
                                                 BitmapSizeOptions.FromEmptyOptions());
}
