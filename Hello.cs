using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace CadExtension;

public class Hello
{
    [CommandMethod("HELLO")]
    public void HelloCommand()
    {
        Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
        ed.WriteMessage("Hello, World!\n");
    }
}