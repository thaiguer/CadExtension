namespace CadExtension.LayerObjects;

internal class VisibleLayerSet : List<LayersInfo>
{
    public VisibleLayerSet(
        int index,
        string name,
        LayersInfo layersInfo)
    {
        Index = index;
        Name = name;
        LayersInfo = layersInfo;
    }

    internal int Index { get; }
    internal string Name { get; } = string.Empty;
    internal LayersInfo LayersInfo { get; } = [];
}