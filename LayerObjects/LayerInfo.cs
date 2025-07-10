namespace CadExtension.LayerObjects;

internal class LayerInfo
{
    public string LayerName { get; }
    public bool IsOn { get; }

    public LayerInfo(string layerName, bool isOn)
    {
        LayerName = layerName;
        IsOn = isOn;
    }
}