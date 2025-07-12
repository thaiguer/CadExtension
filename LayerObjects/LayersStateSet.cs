namespace CadExtension.LayerObjects;

internal class LayersStateSet
{
    public List<LayerState> LayerStates { get; private set; } = [];

    public LayersStateSet(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    internal void SetNewLayersState()
    {
        CadApi.LayerState.UpdateLayersState(LayerStates);
    }

    internal void ReadCurrentLayersState()
    {
        LayerStates = CadApi.LayerState.GetLayersState();
    }
}