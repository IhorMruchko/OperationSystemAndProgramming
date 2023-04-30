using AForge.Imaging.Filters;
using Graphics.Tools;

namespace Graphics.MenuOperations.ToolsMenuOperations.FilterToolsMenuOperations;

internal class WaterWaveFilterMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.WAVE_FILTER;

    public override Key[] KeyBind => new[] { Key.LeftCtrl, Key.W };

    protected override string Name => Constants.MenuOperationsSettings.Names.WAVE_FILTER;

    protected override string IconFileSource => Constants.IO.Images.Icons.WaterWaveIcon;

    public override void HandleEvent(MainWindow source)
    {
        source.CurrentTool = new FilteringTool(new WaterWave()
        {
            HorizontalWavesCount = 3,
            HorizontalWavesAmplitude = 5,
            VerticalWavesCount = 3,
            VerticalWavesAmplitude = 5
        });
    }
}
