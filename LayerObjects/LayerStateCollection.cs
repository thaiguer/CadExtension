namespace CadExtension.LayerObjects;

public class LayerStateCollection
{
    public string Name { get; set; } = string.Empty;
    public List<LayerState> LayerStates { get; set; } = [];
}