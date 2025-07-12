namespace CadExtension.LayerObjects;

public class LayersStateView
{
    public string Name { get; set; }
    public List<LayerState> LayerStates { get; set; }

    public LayersStateView(string name, List<LayerState> layerStates)
    {
        Name = name;
        LayerStates = layerStates;
    }
}