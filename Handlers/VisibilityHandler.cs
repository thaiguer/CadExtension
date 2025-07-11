using CadExtension.CadApi;
using CadExtension.LayerObjects;
using System.Text.Json;
using System;

namespace CadExtension.Handlers;

internal class VisibilityHandler
{
    private string _key = "MyExtension";
    
    internal void SaveCurrentViewCommand()
    {
        var name = Prompt.AskUserForString("Digite um nome para o Layer Visible Set:");
        if (name == string.Empty) return;
                
        var layersInfo = new VisibleLayerSet(0, name, new LayersInfo());
        string jsonString = JsonSerializer.Serialize(layersInfo);

        var xrecordsOnDocument = new XrecordsOnDocument();
        xrecordsOnDocument.WriteStringToXrecord(_key, jsonString);
    }

    internal void RemoveSavedViewsCommand()
    {

    }

    internal void RestoreSavedViewCommand()
    {
        var layersInfo = JsonSerializer.Deserialize<VisibleLayerSet>(json);
        var layersState = new VisibleLayerSet();
    }
}