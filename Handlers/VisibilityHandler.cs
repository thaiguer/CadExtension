using CadExtension.CadApi;
using CadExtension.LayerObjects;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CadExtension.Handlers;

internal class VisibilityHandler
{
    string myKey = "MyKey";
    
    internal void SaveCurrentViewCommand()
    {
        var name = Prompt.AskUserForString("Digite um nome para o salvar a CurrentView:");
        if (name == string.Empty) return;

        var currentStateView = Layers.GetLayersState();
        var jsonObject = JsonSerializer.Serialize(currentStateView);

        var xrecordsOnDocument = new XrecordsOnDocument();
        xrecordsOnDocument.WriteStringToXrecord(myKey, jsonObject);
    }

    internal void RemoveSavedViewsCommand()
    {

    }

    internal void RestoreSavedViewCommand()
    {
        var xrecordsOnDocument = new XrecordsOnDocument();
        var savedJsonObject = xrecordsOnDocument.ReadStringFromXrecord(myKey);
        var savedStateView = JsonSerializer.Deserialize<List<LayerState>>(savedJsonObject);
        if(savedStateView != null)
        {
            Layers.UpdateLayersState(savedStateView);
        }
    }
}