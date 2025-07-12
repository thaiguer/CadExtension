using CadExtension.CadApi;
using CadExtension.LayerObjects;
using System.Text.Json;
using System;

namespace CadExtension.Handlers;

internal class VisibilityHandler
{
    internal void SaveCurrentViewCommand()
    {
        var name = Prompt.AskUserForString("Digite um nome para o salvar a CurrentView:");
        if (name == string.Empty) return;

        var layerStateSet = new LayersStateSet(name);
        layerStateSet.ReadCurrentLayersState();

        var layersStateSetCollection = new LayersStateSetCollection();
        layersStateSetCollection.Append(layerStateSet);
    }

    internal void RemoveSavedViewsCommand()
    {

    }

    internal void RestoreSavedViewCommand()
    {
        var layersStateSetCollection = new LayersStateSetCollection();
        foreach (var layerStateSet in layersStateSetCollection.LayerStates)
        {
            Prompt.WriteNewLine(layerStateSet.Name);
        }
    }
}