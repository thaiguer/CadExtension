namespace CadExtension.LayerObjects;

public class LayerState
{
    public string LayerName { get; }
    public bool IsOn { get; }

    public LayerState(string layerName, bool isOn)
    {
        LayerName = layerName;
        IsOn = isOn;
    }
}