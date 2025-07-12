using CadExtension.CadApi;
using System.Text.Json;

namespace CadExtension.LayerObjects;

internal class LayersStateSetCollection
{
    internal string Key { get; } = "MyExtension";
    private List<LayersStateSet> _layerStates;

    internal LayersStateSetCollection()
    {
        _layerStates = new List<LayersStateSet>();
    }

    internal List<LayersStateSet> LayerStates
    {
        get { return UpdateFromMemory(); }
        set { }
    }

    private List<LayersStateSet> UpdateFromMemory()
    {
        var xrecordsOnDocument = new XrecordsOnDocument();
        var layersStateSetCollectionJson = xrecordsOnDocument.ReadStringFromXrecord(Key);

        try
        {
            _layerStates = JsonSerializer.Deserialize<List<LayersStateSet>>(layersStateSetCollectionJson) ?? new List<LayersStateSet>();
        }
        catch
        {
            _layerStates = new List<LayersStateSet>();
        }

        return _layerStates;
    }

    internal void Append(LayersStateSet layerStateSet)
    {
        _layerStates = UpdateFromMemory();
        _layerStates.Add(layerStateSet);
        var xrecordsOnDocument = new XrecordsOnDocument();
        string layersStateSetCollectionJson = JsonSerializer.Serialize(_layerStates);
        xrecordsOnDocument.WriteStringToXrecord(Key, layersStateSetCollectionJson);
    }
}