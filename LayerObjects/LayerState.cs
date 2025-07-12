namespace CadExtension.LayerObjects;

internal class LayerState
{
    public string LayerName { get; }
    public bool IsOn { get; }

    public LayerState(string layerName, bool isOn)
    {
        LayerName = layerName;
        IsOn = isOn;
    }
}