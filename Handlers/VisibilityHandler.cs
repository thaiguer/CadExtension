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

        var xrecordsOnDocument = new XrecordsOnDocument();
        var savedJsonObject = xrecordsOnDocument.ReadStringFromXrecord(myKey);
        
        RecordStates savedStateViews;
        if(savedJsonObject != string.Empty)
        {
            savedStateViews = JsonSerializer.Deserialize<RecordStates>(savedJsonObject) ?? new RecordStates(new List<LayerStateCollection>());
        }
        else
        {
            savedStateViews = new RecordStates(new List<LayerStateCollection>());
        }         

        var currentState = Layers.GetLayersState();
        currentState.Name = name;
        savedStateViews.LayerStates.Add(currentState);

        var newSavedStateViews = JsonSerializer.Serialize(savedStateViews);
        xrecordsOnDocument.WriteStringToXrecord(myKey, newSavedStateViews);
    }

    internal void RemoveAllSavedViewsCommand()
    {
        var xrecordsOnDocument = new XrecordsOnDocument();
        xrecordsOnDocument.DeleteXRecord(myKey);
    }

    internal void RemoveOneSavedViewCommand()
    {
        var xrecordsOnDocument = new XrecordsOnDocument();
        var savedJsonObject = xrecordsOnDocument.ReadStringFromXrecord(myKey);
        var savedStateViews = JsonSerializer.Deserialize<RecordStates>(savedJsonObject) ?? new RecordStates(new List<LayerStateCollection>());

        if (savedStateViews.LayerStates.Count <= 0)
        {
            Prompt.WriteNewLine("Não há views salvas");
            return;
        }

        int i = 0;
        foreach (var layerStates in savedStateViews.LayerStates)
        {
            Prompt.WriteNewLine(savedStateViews.LayerStates[i].Name);
            i++;
        }
        int index = Prompt.AskUserForInt("Digite o índice da View para remover:");

        if (index < 0) return;
        if (index >= savedStateViews.LayerStates.Count)
        {
            Prompt.WriteNewLine("Índice inválido");
            return;
        }

        RemoveSavedView(index);
    }

    private void RemoveSavedView(int index)
    {
        var xrecordsOnDocument = new XrecordsOnDocument();
        var savedJsonObject = xrecordsOnDocument.ReadStringFromXrecord(myKey);

        if (savedJsonObject == string.Empty) return;
        RecordStates savedStateViews = JsonSerializer.Deserialize<RecordStates>(savedJsonObject) ?? new RecordStates(new List<LayerStateCollection>());

        savedStateViews.LayerStates.RemoveAt(index);

        var newSavedStateViews = JsonSerializer.Serialize(savedStateViews);
        xrecordsOnDocument.WriteStringToXrecord(myKey, newSavedStateViews);
    }

    internal void RestoreSavedViewCommand()
    {
        var xrecordsOnDocument = new XrecordsOnDocument();
        var savedJsonObject = xrecordsOnDocument.ReadStringFromXrecord(myKey);
        var savedStateViews = JsonSerializer.Deserialize<RecordStates>(savedJsonObject) ?? new RecordStates(new List<LayerStateCollection>());

        if(savedStateViews.LayerStates.Count <= 0)
        {
            Prompt.WriteNewLine("Não há views salvas");
            return;
        }

        int i = 0;
        foreach(var layerStates in savedStateViews.LayerStates)
        {
            Prompt.WriteNewLine(savedStateViews.LayerStates[i].Name);
            i++;
        }
        int index = Prompt.AskUserForInt("Digite o índice da View para restaurar:");

        if (index < 0) return;
        if (index >= savedStateViews.LayerStates.Count)
        {
            Prompt.WriteNewLine("Índice inválido");
            return;
        }

        Layers.UpdateLayersState(savedStateViews.LayerStates[index]);
    }
}