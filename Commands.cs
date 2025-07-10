using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace CadExtension;

public class Commands
{
    [CommandMethod("VS_SAVE_CURRENT")]
    public void SaveCurrentViewCommand()
    {
        var visibilityHandler = new VisibilityHandler();
        visibilityHandler.SaveCurrentViewCommand();
    }

    [CommandMethod("VS_REMOVE_SAVED")]
    public void RemoveSavedViewsCommand()
    {
        var visibilityHandler = new VisibilityHandler();
        visibilityHandler.RemoveSavedViewsCommand();
    }

    [CommandMethod("VS_RESTORE_SAVED")]
    public void RestoreSavedViewCommand()
    {
        var visibilityHandler = new VisibilityHandler();
        visibilityHandler.RestoreSavedViewCommand();
    }
}