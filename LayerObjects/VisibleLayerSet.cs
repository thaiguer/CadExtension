namespace CadExtension.LayerObjects;

internal class VisibleLayerSet : List<LayersInfo>
{
    internal int Index { get; }
    internal LayersInfo LayersInfo { get; } = [];
}