using System.Linq;
using System.Windows;

namespace Graphics.BoundsValidators;

public static class BoundValidatorsManager
{
    private readonly static List<BoundValidator> _managers = new()
    {
        new LineBoundValidator(),
        new ImageBoundValidator(),
        new EllipseBoundValidator(),
        new RectangleBoundValidator(),
    };

    public static BoundValidator GetValidator(UIElement element)
    {
        return _managers.FirstOrDefault(manager => manager.IsTargettingType(element)) 
            ?? new DefaultBoundValidator();
    }
}
