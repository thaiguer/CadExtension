using CadExtension.CadApi;
using System.Text.Json;

namespace CadExtension.LayerObjects;

internal class LayersStateSetCollection
{
    internal string Key { get; } = "MyExtension";
    internal List<LayersStateSet> LayerStates
    {
        get { return ReadFromMemory(); }
        set { }
    }

    private List<LayersStateSet> ReadFromMemory()
    {
        var xrecordsOnDocument = new XrecordsOnDocument();
        var layersStateSetCollectionJson = xrecordsOnDocument.ReadStringFromXrecord(Key);

        try
        {
            return JsonSerializer.Deserialize<List<LayersStateSet>>(layersStateSetCollectionJson) ?? [];
        }
        catch
        {
            return [];
        }
    }

    internal void Append(LayersStateSet layerStateSet)
    {
        LayerStates = ReadFromMemory();
        LayerStates.Add(layerStateSet);
        var xrecordsOnDocument = new XrecordsOnDocument();
        string layersStateSetCollectionJson = JsonSerializer.Serialize(LayerStates);
        xrecordsOnDocument.WriteStringToXrecord(Key, layersStateSetCollectionJson);
    }
}