using CadExtension.CadApi;
using CadExtension.LayerObjects;
using System.Text.Json;

namespace CadExtension.Handlers;

internal class VisibilityHandler
{
    string myKey = "MyKey";
    
    internal void SaveCurrentViewCommand()
    {
        string name = Prompt.AskUserForString("Digite um nome para o salvar a CurrentView:");
        if (name == string.Empty) return;
        //salvar o nome da view

        var xrecordsOnDocument = new XrecordsOnDocument();
        var savedJsonObject = xrecordsOnDocument.ReadStringFromXrecord(myKey);
        
        RecordStates savedStateViews;
        if(savedJsonObject != string.Empty)
        {
            savedStateViews = JsonSerializer.Deserialize<RecordStates>(savedJsonObject) ?? new RecordStates(new List<List<LayerState>>());
        }
        else
        {
            savedStateViews = new RecordStates(new List<List<LayerState>>());
        }         

        var currentState = Layers.GetLayersState();
        savedStateViews.LayerStates.Add(currentState);

        var newSavedStateViews = JsonSerializer.Serialize(savedStateViews);
        xrecordsOnDocument.WriteStringToXrecord(myKey, newSavedStateViews);
    }

    internal void RemoveSavedViewsCommand()
    {

    }

    internal void RestoreSavedViewCommand()
    {
        var xrecordsOnDocument = new XrecordsOnDocument();
        var savedJsonObject = xrecordsOnDocument.ReadStringFromXrecord(myKey);
        var savedStateViews = JsonSerializer.Deserialize<RecordStates>(savedJsonObject) ?? new RecordStates(new List<List<LayerState>>());

        if(savedStateViews.LayerStates.Count <= 0)
        {
            Prompt.WriteLine("Não há views salvas");
            return;
        }

        int i = 0;
        foreach(var layerStates in savedStateViews.LayerStates)
        {
            //acrescentar o nome da view
            Prompt.WriteLine(savedStateViews.LayerStates[i].ToString());
            i++;
        }
        int index = Prompt.AskUserForInt("Digite o índice da View para restaurar:");

        if (index < 0) return;
        if (index >= savedStateViews.LayerStates.Count)
        {
            Prompt.WriteLine("Índice inválido");
            return;
        }

        Layers.UpdateLayersState(savedStateViews.LayerStates[index]);
    }
}