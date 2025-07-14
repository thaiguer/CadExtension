using Autodesk.AutoCAD.Runtime;

namespace CadExtension.Handlers;

public class Commands
{
    [CommandMethod("VS_SAVE")]
    public void SaveCurrentViewCommand()
    {
        var visibilityHandler = new VisibilityHandler();
        visibilityHandler.SaveCurrentViewCommand();
    }

    [CommandMethod("VS_RESTORE")]
    public void RestoreSavedViewCommand()
    {
        var visibilityHandler = new VisibilityHandler();
        visibilityHandler.RestoreSavedViewCommand();
    }

    [CommandMethod("VS_REMOVE_ALL")]
    public void RemoveAllSavedViewsCommand()
    {
        var visibilityHandler = new VisibilityHandler();
        visibilityHandler.RemoveAllSavedViewsCommand();
    }

    [CommandMethod("VS_REMOVE_ONE")]
    public void RemoveOneSavedViewCommand()
    {
        var visibilityHandler = new VisibilityHandler();
        visibilityHandler.RemoveOneSavedViewCommand();
    }
}