using CadExtension.CadApi;
using CadExtension.LayerObjects;

namespace CadExtension.Handlers;

internal class VisibilityHandler
{
    internal void SaveCurrentViewCommand()
    {
        var layersInfo = new LayersInfo();
        layersInfo.GetLayersState();

        var name = Prompt.AskUserForString("Digite um nome para o Layer Visible Set:");
        
        var layersState = new VisibleLayerSet();
    }

    internal void RemoveSavedViewsCommand()
    {

    }

    internal void RestoreSavedViewCommand()
    {

    }
}