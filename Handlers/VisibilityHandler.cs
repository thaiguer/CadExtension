using CadExtension.CadApi;
using CadExtension.LayerObjects;
using System.Text.Json;
using System;

namespace CadExtension.Handlers;

internal class VisibilityHandler
{
    internal void SaveCurrentViewCommand()
    {
        var name = Prompt.AskUserForString("Digite um nome para o Layer Visible Set:");
        if (name == string.Empty) return;

        var layerStateSet = new LayersStateSet(name);
        layerStateSet.ReadCurrentLayersState();

        var layersStateSetCollection = new LayersStateSetCollection();
        layersStateSetCollection.Append(layerStateSet);
        
        //tratar o erro caso append (nome repetido)
    }

    internal void RemoveSavedViewsCommand()
    {

    }

    internal void RestoreSavedViewCommand()
    {
        var layersStateSetCollection = new LayersStateSetCollection();

        var a = layersStateSetCollection.LayerStates;

        foreach (var layerStateSet in a)
        {
            Prompt.WriteNewLine(layerStateSet.Name);
        }
    }
}