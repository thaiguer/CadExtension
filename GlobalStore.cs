using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System.Xml.Linq;

namespace CadExtension;

public class Class1
{
    [CommandMethod("Test123Write")]
    public void WriteTest()
    {
        var xHandler = new XrecordsOnDocument();
        xHandler.WriteJsonToXrecord("MyThing", "aaaSecretaaa");
    }

    [CommandMethod("Test123Read")]
    public void ReadTest()
    {
        var xHandler = new XrecordsOnDocument();
        var result = xHandler.ReadJsonFromXrecord("MyThing");

        Prompt.WriteNewLine(result);
    }
}