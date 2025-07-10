using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;

namespace CadExtension.Examples;

public class Hello
{
    [CommandMethod("HELLO")]
    public void HelloCommand()
    {
        Editor ed = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Editor;
        ed.WriteMessage("Hello, World!\n");
    }
}