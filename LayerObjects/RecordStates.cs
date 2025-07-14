namespace CadExtension.LayerObjects;

public class RecordStates
{
    public List<LayerStateCollection> LayerStates { get; set; }

    public RecordStates(List<LayerStateCollection> layerStates)
    {
        LayerStates = layerStates;
    }
}