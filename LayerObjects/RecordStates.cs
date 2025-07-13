namespace CadExtension.LayerObjects;

public class RecordStates
{
    public List<List<LayerState>> LayerStates { get; set; }

    public RecordStates(List<List<LayerState>> layerStates)
    {
        LayerStates = layerStates;
    }
}