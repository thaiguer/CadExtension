namespace CadExtension;

internal class LayerInfo
{
    public string LayerName { get; }
    public bool IsOn { get; set; }

    public LayerInfo(string layerName, bool isOn)
    {
        LayerName = layerName;
        IsOn = isOn;
    }
}