using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace CadExtension;

public class Class1
{
    [CommandMethod("HELLO")]
    public void HelloCommand()
    {
        // Get the AutoCAD editor.
        Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

        // Display the "Hello, World!" message.
        ed.WriteMessage("Hello, World!\n");
    }
}