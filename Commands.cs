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
        Prompt.WriteNewLine("Save Current Command not implemented");
    }

    [CommandMethod("VS_REMOVE_SAVED")]
    public void RemoveSavedViewsCommand()
    {
        Prompt.WriteNewLine("Remove saved views Command not implemented");
    }

    [CommandMethod("VS_RESTORE_SAVED")]
    public void RestoreSavedViewCommand()
    {
        Prompt.WriteNewLine("Restore saved view Command not implemented");
    }
}